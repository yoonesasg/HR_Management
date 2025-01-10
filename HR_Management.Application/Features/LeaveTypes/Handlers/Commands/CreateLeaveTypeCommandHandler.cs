using AutoMapper;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeDTOValidator();
            var validation = validator.Validate(request.CreateLeaveTypeDTO);
            if (validation.IsValid == false)
                throw new ValidationException(validation);

            var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDTO);
            var result = await _leaveTypeRepository.Add(leaveType);
            return result.Id;
        }
    }
}
