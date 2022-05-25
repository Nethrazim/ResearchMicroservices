using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SO.BusinessLayer.Services;
using SO.BusinessLayer.Institution.Entities.DTOs;
using SO.DataLayer.Institution.Repositories;
using SO.BusinessLayer.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using SO.API.Helpers;

using Address = SO.DataLayer.Institution.Model.Address;

namespace SO.BusinessLayer.Institution.Services
{
    public class AddressService : GenericService<IAddressRepository, AddressDTO, Address,int>, IAddressService
    {
        public AddressService(IAddressRepository repository, IMapper mapper, IConfiguration configuration)
            : base(repository, configuration, mapper)
        {
        }

        public async Task<AddressDTO> GetByInstitutionId(int institutionId)
        {
            var institution = Mapper.Map<AddressDTO>(await Repository.GetByInstitutionId(institutionId));
            if (institution == null)
            {
                ResponseHelper.ReturnNotFound("Address not found");
            }

            return institution;
        }
    }

}
