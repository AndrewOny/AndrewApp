using AndrewApp.Models;
using AndrewCore.DTOs;
using AutoMapper;

namespace AndrewApp.Mapping
{
    public class MvcMapperProfile : Profile
    {
        public MvcMapperProfile() 
        {
            CreateMap<AdminUserDto, AdminModel>()
                .ForMember(adminModel => adminModel.Id, opt => opt.MapFrom(adminUserDto => adminUserDto.Id));
            CreateMap<AdminModel, AdminUserDto>()
                .ForMember(adminUserDto => adminUserDto.Id, opt => opt.MapFrom(adminModel => adminModel.Id));
        }
    }
}
