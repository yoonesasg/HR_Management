using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocation;
using HR_Management.Application.Features.LeaveRequests.Requests.Queries;
using HR_Management.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationsListRequestHandler : IRequestHandler<GetLeaveAllocationsListRequest, List<LeaveAllocationDTO>>
    {
        private readonly ILeaveAllocationRepository _LeaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetLeaveAllocationsListRequestHandler(ILeaveAllocationRepository LeaveAllocationRepository, IMapper mapper)
        {
            _LeaveAllocationRepository = LeaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationsListRequest request, CancellationToken cancellationToken)
        {
            var LeaveAllocations = await _LeaveAllocationRepository.GetAll();
            return _mapper.Map<List<LeaveAllocationDTO>>(LeaveAllocations);
        }
    }
}
