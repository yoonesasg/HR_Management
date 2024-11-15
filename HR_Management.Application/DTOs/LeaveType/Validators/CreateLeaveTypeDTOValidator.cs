using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDTOValidator : AbstractValidator<CreateLeaveTypeDTO>
    {
        public CreateLeaveTypeDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull();
            RuleFor(x => x.DefaultDay).NotEmpty().WithMessage("{ PropertyName} is Required").NotNull();
        }
    }
}
