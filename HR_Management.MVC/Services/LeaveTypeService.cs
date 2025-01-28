using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services
{
    public class LeaveTypeService : BaseHttpService,ILeaveTypeService
    {
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;

        public LeaveTypeService(ILocalStorageService localStorageService, IClient client, IMapper mapper) : base(localStorageService, client)
        {
            _localStorageService = localStorageService;
            _client = client;
            _mapper = mapper;
        }

        public Task<List<LeaveTypeViewModel>> GetLeaveTypes()
        {
            throw new NotImplementedException();
        }

        public Task<LeaveTypeViewModel> GetLeaveTypeDetails(int leaveTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeViewModel createLeaveTypeViewModel)
        {
            try
            {
                var responce = new Response<int>();
                CreateLeaveTypeDTO createLeaveTypeDto = _mapper.Map<CreateLeaveTypeDTO>(createLeaveTypeViewModel);

                // TODO : Auth

                await _client.LeaveTypePOSTAsync(createLeaveTypeDto);
                return responce;
            }
            catch (ApiException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task UpdateLeaveType(LeaveTypeViewModel updateLeaveTypeViewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteLeaveType(int leaveTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
