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

namespace SO.BusinessLayer.Institution.Services
{
    public class InstitutionService : GenericService<IInstitutionRepository, SO.DataLayer.Institution.Model.Institution,int>, IInstitutionService
    {
        private IMapper Mapper;
        public InstitutionService(IInstitutionRepository institutionRepository, IMapper mapper, IConfiguration configuration)
            : base(institutionRepository, configuration)
        {
            Mapper = mapper;
        }

        public async Task<InstitutionDTO> CreateInstitutionAsync(string name, Guid adminId)
        {
            if (await this.GetByName(name) != null)
            {
                ResponseHelper.ReturnBadRequest("Institution already exists");
            }
            DateTime now = DateTime.Now;

            InstitutionDTO entity = Mapper.Map<InstitutionDTO>(await Repository.CreateAsync(new SO.DataLayer.Institution.Model.Institution()
            {
                Name = name,
                AdminId = adminId,
                IsActive = true,
                CreatedDate = now,
                UpdatedDate = now,
            }));

            await Repository.SaveChanges();
            return entity;
        }

        public async Task<InstitutionDTO> GetByName(string name)
        {
            return Mapper.Map<InstitutionDTO>(await Repository.GetByName(name));
        }
    }

}
