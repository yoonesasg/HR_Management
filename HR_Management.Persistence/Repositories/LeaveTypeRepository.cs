using HR_Management.Application.Persistence.Contracts;
using HR_Management.Domain;
using HR_Management.Persistence.Context;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType> , ILeaveTypeRepository
    {
        private readonly HR_ManagementDbContext _context;
        public LeaveTypeRepository(HR_ManagementDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
