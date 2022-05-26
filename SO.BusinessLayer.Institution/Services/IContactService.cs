using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SO.BusinessLayer.Institution.Entities.DTOs;
using SO.BusinessLayer.Services;
using Contact = SO.DataLayer.Institution.Model.Contact;
namespace SO.BusinessLayer.Institution.Services
{
    public interface IContactService : IGenericService<ContactDTO, Contact, int>
    {
        Task<ContactDTO> GetByInstitutionId(int institutionId);
    }
}
