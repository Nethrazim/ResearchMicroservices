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
using Contact = SO.DataLayer.Institution.Model.Contact;
namespace SO.BusinessLayer.Institution.Services
{
    public class ContactService : GenericService<IContactRepository, ContactDTO, Contact,int>, IContactService
    {
        public ContactService(IContactRepository repository, IMapper mapper, IConfiguration configuration)
            : base(repository, configuration, mapper)
        {
        }
        public async Task<ContactDTO> GetByInstitutionId(int institutionId)
        {
            var contact = Mapper.Map<ContactDTO>(await Repository.GetByInstitutionId(institutionId));
            if (contact == null)
            {
                ResponseHelper.ReturnNotFound("Contact not found");
            }

            return contact;
        }
    }

}
