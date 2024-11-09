using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Features.LeaveRequests.Requests.Queries;
using HR_Management.Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestsListRequestHandler : IRequestHandler<GetLeaveRequestsListRequest, List<LeaveRequestDTO>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public GetLeaveRequestsListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestDTO>> Handle(GetLeaveRequestsListRequest request, CancellationToken cancellationToken)
        {
            var leaveRequests = await _leaveRequestRepository.GetRequestsList();
            return _mapper.Map<List<LeaveRequestDTO>>(leaveRequests);
        }
    }
}
