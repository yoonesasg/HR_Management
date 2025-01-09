using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Persistence.Context
{
    public class HR_ManagementDbContext : DbContext
    {
        #region Constructor
        public HR_ManagementDbContext(DbContextOptions<HR_ManagementDbContext> options) : base(options)
        {

        }
        #endregion

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    }
}
