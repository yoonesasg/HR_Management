namespace HR_Management.Application.DTOs.LeaveAllocation
{
    public interface ILeaveAllocationDTO
    {
        public int LeaveTypeId { get; set; }
        public int Priod { get; set; }
        public int NumberOfDays { get; set; }
    }
}
