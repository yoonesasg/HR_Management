using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Handlers.Commands;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Profiles;
using HR_Management.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR_Management.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepository;
        private readonly CreateLeaveTypeDTO _createLeaveTypeDTO;
        public CreateLeaveTypeCommandHandlerTest()
        {
            _mockRepository = MockLeaveRepository.GetLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(m => m.AddProfile<MappingProfile>());
            _mapper = mapperConfig.CreateMapper();
            _createLeaveTypeDTO = new CreateLeaveTypeDTO
            {
                Id = 3,
                DefaultDay = 10,
                Name = "Test"
            };
        }

        [Fact]
        public async Task CreateLeaveTypeTest()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockRepository.Object, _mapper);
            var result = handler.Handle(new CreateLeaveTypeCommand(){CreateLeaveTypeDTO = _createLeaveTypeDTO}, CancellationToken.None);
            await result.ShouldBeOfType<Task<int>>();
            var leaveTypes = await _mockRepository.Object.GetAll();
            leaveTypes.Count.ShouldBe(3);
        }
    }
}
