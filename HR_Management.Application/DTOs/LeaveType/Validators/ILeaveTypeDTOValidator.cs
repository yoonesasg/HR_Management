using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDTOValidator : AbstractValidator<ILeaveTypeDTO>
    {
        public ILeaveTypeDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} must not be empty!")
                .NotNull().WithMessage("{PropertyName} must not be null!");
            RuleFor(x => x.DefaultDay)
                .NotEmpty().WithMessage("{PropertyName} must not be empty!")
                .NotNull().WithMessage("{PropertyName} must not be null!");
        }
    }
}
