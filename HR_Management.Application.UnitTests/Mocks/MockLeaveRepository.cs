using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using Moq;

namespace HR_Management.Application.UnitTests.Mocks
{
    public static class MockLeaveRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDay = 10,
                    Name = "Test Vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDay = 12,
                    Name = "Test Sick"
                }
            };

            var mockRepository = new Mock<ILeaveTypeRepository>();
            mockRepository.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);

            mockRepository.Setup(r => r.Add(It.IsAny<LeaveType>()))
                .ReturnsAsync((LeaveType leaveType) =>
                {
                    leaveTypes.Add(leaveType);
                    return leaveType;
                });


            return mockRepository;
        }
    }
}
