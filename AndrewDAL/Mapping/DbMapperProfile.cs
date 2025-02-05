using AndrewCore.DTOs;
using AndrewDAL.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewDAL.Mapping
{
    public class DbMapperProfile : Profile
    {
        public DbMapperProfile()
        {
            CreateMap<AdminUser, AdminUserDto>().ReverseMap();
            CreateMap<CmsSectionType, CmsSectionTypeDto>().ReverseMap();
            CreateMap<CmsSection, CmsSectionDto>().ReverseMap();
            CreateMap<ContactForm, ContactFormDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<VisitorMessage, VisitorMessageDto>().ReverseMap();
        }
    }
}
