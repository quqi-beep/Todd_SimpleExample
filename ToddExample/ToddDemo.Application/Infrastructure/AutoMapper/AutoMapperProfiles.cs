using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ToddDemo.Application.Responses;

namespace ToddDemo.Application.Infrastructure.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
