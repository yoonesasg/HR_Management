using AutoMapper;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Requests.Queries;
using HR_Management.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public GetLeaveTypeDetailRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDTO> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDTO>(leaveType);
        }
    }
}
