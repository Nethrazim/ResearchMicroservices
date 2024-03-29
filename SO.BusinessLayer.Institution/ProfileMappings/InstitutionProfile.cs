﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SO.BusinessLayer.Institution.Entities.DTOs;

namespace SO.BusinessLayer.Institution.ProfileMappings
{
    public class InstitutionProfile : Profile
    {
        public InstitutionProfile()
        {
            CreateMap<InstitutionDTO, SO.DataLayer.Institution.Model.Institution>()
                .ReverseMap();
            CreateMap<UserDTO, SO.DataLayer.Institution.Model.User>()
                .ReverseMap();
            CreateMap<AddressDTO, SO.DataLayer.Institution.Model.Address>()
                .ReverseMap();
            CreateMap<ContactDTO, SO.DataLayer.Institution.Model.Contact>()
                .ReverseMap();
        }
    }
}
