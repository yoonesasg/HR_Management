using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Handlers.Queries;
using HR_Management.Application.Features.LeaveTypes.Requests.Queries;
using HR_Management.Application.Profiles;
using HR_Management.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR_Management.Application.UnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepository;
        public GetLeaveTypeListRequestHandlerTest()
        {
            _mockRepository = MockLeaveRepository.GetLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(m => m.AddProfile<MappingProfile>());
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_mockRepository.Object, _mapper);
            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<LeaveTypeDTO>>();
            result.Count.ShouldBe(2);
        }
    }
}
