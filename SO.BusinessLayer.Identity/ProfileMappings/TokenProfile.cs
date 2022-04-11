using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SO.BusinessLayer.Identity.Entities.DTOs;
using SO.BusinessLayer.Tokens;

namespace SO.BusinessLayer.Identity.ProfileMappings
{
    internal class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<Token, TokenDTO>().ReverseMap();
        }
    }
}
