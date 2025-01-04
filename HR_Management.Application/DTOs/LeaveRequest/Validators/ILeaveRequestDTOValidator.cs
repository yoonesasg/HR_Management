using FluentValidation;
using HR_Management.Application.Persistence.Contracts;

namespace HR_Management.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDTOValidator : AbstractValidator<ILeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} Must Be Greater Than {ComparisonValue}");
            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} Must Be Greater Than {ComparisonValue}");
            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExist = await _leaveTypeRepository.Exist(id);
                    return !leaveTypeExist;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
