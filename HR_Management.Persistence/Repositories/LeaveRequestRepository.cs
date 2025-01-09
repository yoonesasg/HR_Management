using HR_Management.Application.Persistence.Contracts;
using HR_Management.Domain;
using HR_Management.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HR_ManagementDbContext _context;
        public LeaveRequestRepository(HR_ManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<LeaveRequest> GetRequestDetail(int Id)
        {
            return await _context.LeaveRequests.Include(lr => lr.LeaveType).FirstOrDefaultAsync(lr => lr.Id == Id);
        }

        public async Task<List<LeaveRequest>> GetRequestsList()
        {
            return await _context.LeaveRequests.Include(lr=>lr.LeaveType).ToListAsync();
        }
    }
}
