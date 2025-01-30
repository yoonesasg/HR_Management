using AutoMapper;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveTypeDTO, LeaveTypeViewModel>().ReverseMap();
            CreateMap<CreateLeaveTypeDTO, CreateLeaveTypeViewModel>().ReverseMap();
            CreateMap<UpdateLeaveTypeDTO, LeaveTypeViewModel>().ReverseMap();
        }
    }
}
