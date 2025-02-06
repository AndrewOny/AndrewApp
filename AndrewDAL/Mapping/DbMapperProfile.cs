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
        }
    }
}
