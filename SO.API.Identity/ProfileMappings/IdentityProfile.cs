using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SO.API.Identity.Model.Requests;
using SO.BusinessLayer.Identity.Entities.DTOs;
using SO.DataLayer.Identity.Model;
using SO.Messaging.Events.Identity;

namespace SO.BusinessLayer.Identity.ProfileMappings
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<CreateUserRequest,User>();
            CreateMap<UserDTO, UserChanged>();
            CreateMap<User, UserChanged>();
        }
    }
}
