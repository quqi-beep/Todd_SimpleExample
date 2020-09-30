using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ToddDemo.Application.Responses;

namespace ToddDemo.Application.Infrastructure.AutoMapper
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<UserDto, UserAgeDto>().ReverseMap();
        }
    }
}
