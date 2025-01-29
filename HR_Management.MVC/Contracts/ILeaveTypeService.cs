using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeViewModel>> GetLeaveTypes();
        Task<LeaveTypeViewModel> GetLeaveTypeDetails(int leaveTypeId);
        Task<Response<int>> CreateLeaveType(CreateLeaveTypeViewModel createLeaveTypeViewModel);
        Task UpdateLeaveType(int id,LeaveTypeViewModel updateLeaveTypeViewModel);
        Task DeleteLeaveType(int leaveTypeId);
    }
}
