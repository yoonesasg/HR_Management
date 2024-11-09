using HR_Management.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDTO>
    {
        public int Id { get; set; }
    }
}
