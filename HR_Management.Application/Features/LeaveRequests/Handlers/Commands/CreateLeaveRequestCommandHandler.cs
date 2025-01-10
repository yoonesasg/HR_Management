using System;
using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.Models;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeReppository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeReppository, IMapper mapper, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeReppository = leaveTypeReppository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestDTOValidator(_leaveTypeReppository);
            var validation = validator.Validate(request.CreateLeaveRequestDTO);
            if (validation.IsValid == false)
                throw new ValidationException(validation);
            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDTO);
            var result = await _leaveRequestRepository.Add(leaveRequest);

            var email = new Email()
            {
                To = "yoonesasgasg@gmail.com",
                Body = "Salam",
                Subject = "HR_Management"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return result.Id;
        }
    }
}
