using FluentValidation;
using HR_Management.Application.Contracts.Persistence;

namespace HR_Management.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDTOValidator : AbstractValidator<ILeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.Priod).GreaterThan(0).WithMessage("{PropertyName} Must Be Greater than 0");
            RuleFor(p => p.NumberOfDays).GreaterThan(0).WithMessage("{PropertyName} Must Be Greater than 0");
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
