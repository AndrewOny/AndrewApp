using AndrewApp.Models;
using AndrewCore.DTOs;
using AndrewDAL.Models;
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

            CreateMap<CmsSectionDto, CmsSectionModel>()
                .ForMember(cmsSectionModel => cmsSectionModel.Title, opt => opt.MapFrom(cmsSectionDto => cmsSectionDto.Title))
                .ForMember(cmsSectionModel => cmsSectionModel.Description, opt => opt.MapFrom(cmsSectionDto => cmsSectionDto.Description))
                .ForMember(cmsSectionModel => cmsSectionModel.CmsSectionType, opt => opt.MapFrom(cmsSectionDto => cmsSectionDto.CmsSectionType))
                .ForMember(cmsSectionModel => cmsSectionModel.Image, opt => opt.MapFrom(cmsSectionDto => cmsSectionDto.Image));

            CreateMap<CmsSectionDto, CmsSectionType>()
                .ForMember(cmsSectionType => cmsSectionType.Id, opt => opt.MapFrom(cmsSectionDto => cmsSectionDto.CmsSectionTypeId));

            CreateMap<Image, string>().ConvertUsing(image => image.Path);
        }
    }
}
