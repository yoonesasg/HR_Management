using FluentValidation;
using HR_Management.Application.Contracts.Persistence;

namespace HR_Management.Application.DTOs.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDTOValidator : AbstractValidator<UpdateLeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationDTOValidator(_leaveTypeRepository));
        }
    }
}
