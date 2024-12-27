using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDTOValidator : AbstractValidator<CreateLeaveRequestDTO>
    {
        public CreateLeaveRequestDTOValidator()
        {
            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} Must Be Greater Than {ComparisonValue}");
            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} Must Be Greater Than {ComparisonValue}");
            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0).WithMessage("{PropertyName} Must Be Greater Than 0");
        }
    }
}
