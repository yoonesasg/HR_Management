using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDTOValidator : AbstractValidator<CreateLeaveTypeDTO>
    {
        public CreateLeaveTypeDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} must not be empty!")
                .NotNull().WithMessage("{PropertyName} must not be null!");
            RuleFor(x=>x.DefaultDay)
                .NotEmpty().WithMessage("{PropertyName} must not be empty!")
                .NotNull().WithMessage("{PropertyName} must not be null!");
        }
    }
}
