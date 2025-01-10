using FluentValidation;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.Contracts.Persistence;

namespace HR_Management.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDTOValidator : AbstractValidator<CreateLeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationDTOValidator(_leaveTypeRepository));
        }
    }
}
