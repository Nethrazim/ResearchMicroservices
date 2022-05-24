using AutoMapper;
using SO.API.Institution.Model.Requests;
using SO.BusinessLayer.Institution.Entities.DTOs;

namespace SO.API.Institution.Model.Profiles
{
    public class InstitutionProfile : Profile
    {
        public InstitutionProfile()
        {
            CreateMap<CreateAddressRequest, AddressDTO>();
        }
    }
}
