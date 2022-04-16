using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SO.BusinessLayer.Identity.Entities.DTOs;
using SO.DataLayer.Identity.Model;

namespace SO.BusinessLayer.Identity.ProfileMappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>()
                .ForMember(x => x.Salt, y => y.Ignore());   
        }
    }
}
