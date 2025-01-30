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

        public async Task<List<LeaveTypeViewModel>> GetLeaveTypes()
        {
            var leaveTypes = await _client.LeaveTypeAllAsync();
            return _mapper.Map<List<LeaveTypeViewModel>>(leaveTypes);
        }

        public async Task<LeaveTypeViewModel> GetLeaveTypeDetails(int leaveTypeId)
        {
            var leaveType = await _client.LeaveTypeGETAsync(leaveTypeId);
            return _mapper.Map<LeaveTypeViewModel>(leaveType);
        }

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeViewModel createLeaveTypeViewModel)
        {
            try
            {
                var responce = new Response<int>();
                CreateLeaveTypeDTO createLeaveTypeDto = _mapper.Map<CreateLeaveTypeDTO>(createLeaveTypeViewModel);

                // TODO : Auth

                await _client.LeaveTypePOSTAsync(createLeaveTypeDto);
                responce.Success = true;
                return responce;
            }
            catch (ApiException e)
            {
                return ConvertApiException<int>(e);
            }
        }

        public async Task UpdateLeaveType(int id,LeaveTypeViewModel updateLeaveTypeViewModel)
        {
            try
            {
                var leaveType = _mapper.Map<UpdateLeaveTypeDTO>(updateLeaveTypeViewModel);
                await _client.LeaveTypePUTAsync(id, leaveType);
            }
            catch (ApiException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteLeaveType(int leaveTypeId)
        {
            try
            {
                await _client.LeaveTypeDELETEAsync(leaveTypeId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
