using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SO.BusinessLayer.Institution.Entities.DTOs;
using SO.BusinessLayer.Services;
using Address = SO.DataLayer.Institution.Model.Address;
namespace SO.BusinessLayer.Institution.Services
{
    public interface IAddressService : IGenericService<AddressDTO, Address,int>
    {
        Task<AddressDTO> GetByInstitutionId(int institutionId);
    }
}
