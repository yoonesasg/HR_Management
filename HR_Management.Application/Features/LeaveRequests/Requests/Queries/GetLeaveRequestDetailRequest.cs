using HR_Management.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDTO>
    {
        public int Id { get; set; }
    }
}
