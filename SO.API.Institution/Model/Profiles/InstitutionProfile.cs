using AutoMapper;
using SO.API.Institution.Model.Requests;
using SO.BusinessLayer.Institution.Entities.DTOs;

namespace SO.API.Institution.Model.Profiles
{
    public class InstitutionProfile : Profile
    {
        public InstitutionProfile()
        {
            CreateMap<CreateAddressRequest, AddressDTO>()
                .ForMember(src => src.Institution, dst => dst.Ignore());

            CreateMap<UpdateAddressRequest, AddressDTO>()
                .ForMember(src => src.Institution, dst => dst.Ignore());

            CreateMap<CreateContactRequest, ContactDTO>()
                .ForMember(src => src.Institution, dst => dst.Ignore());

            CreateMap<UpdateContactRequest, ContactDTO>();
        }
    }
}
