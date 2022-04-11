using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SO.API.Identity.Entities.Requests;
using SO.DataLayer.Identity.Model;

namespace SO.BusinessLayer.Identity.ProfileMappings
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<CreateUserRequest,User>();
        }
    }
}
