using HR_Management.Domain.Common;

namespace HR_Management.Domain
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
