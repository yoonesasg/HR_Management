using HR_Management.Application.DTOs.Common;

namespace HR_Management.Application.DTOs.LeaveType
{
    public class LeaveTypeDTO : BaseDTO,ILeaveTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
