using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using HR_Management.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly HR_ManagementDbContext _context;
        public LeaveAllocationRepository(HR_ManagementDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<LeaveAllocation> GetRequestDetail(int Id)
        {
            return await _context.LeaveAllocations.Include(la => la.LeaveType).FirstOrDefaultAsync(la => la.Id == Id);
        }

        public Task<List<LeaveAllocation>> GetRequestsList()
        {
            throw new System.NotImplementedException();
        }
    }
}
