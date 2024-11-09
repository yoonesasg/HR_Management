using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocation;
using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Features.LeaveRequests.Requests.Queries;
using HR_Management.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDTO>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);
            return _mapper.Map<LeaveAllocationDTO>(leaveAllocation);
        }
    }
}
