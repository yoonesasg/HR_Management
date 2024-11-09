using HR_Management.Domain.Common;

namespace HR_Management.Domain
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Priod { get; set; }
    }
}
