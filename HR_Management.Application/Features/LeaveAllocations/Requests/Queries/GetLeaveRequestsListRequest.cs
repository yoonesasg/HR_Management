using HR_Management.Application.DTOs.LeaveAllocation;
using MediatR;
using System.Collections.Generic;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveAllocationsListRequest : IRequest<List<LeaveAllocationDTO>>
    {

    }
}
