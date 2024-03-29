﻿using System;
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
    public class InstitutionService : GenericService<IInstitutionRepository, InstitutionDTO, DataLayer.Institution.Model.Institution, int>, IInstitutionService
    {
        public InstitutionService(IInstitutionRepository institutionRepository, IMapper mapper, IConfiguration configuration)
            : base(institutionRepository, configuration, mapper)
        {
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

            return Mapper.Map<InstitutionDTO>(await Repository.GetByAdminId(adminId));
        }

        public async Task<InstitutionDTO> GetByAdminId(Guid adminId)
        {
            InstitutionDTO institution = Mapper.Map<InstitutionDTO>(await Repository.GetByAdminId(adminId));
            if (institution == null)
            {
                ResponseHelper.ReturnNotFound("Institution does not exist");
            }

            return institution;
        }

        public async Task<InstitutionDTO> GetByName(string name)
        {
            return Mapper.Map<InstitutionDTO>(await Repository.GetByName(name));
        }

        public async Task<bool> DeleteAsync(int institutionId)
        {
            if (await this.GetById(institutionId) == null)
            {
                ResponseHelper.ReturnNotFound("Institution not found");
            }

            return await base.DeleteAsync(institutionId);
        }



        public async Task<InstitutionDTO> UpdateAsync(int institutionId, string name)
        {
            InstitutionDTO institution = await this.GetById(institutionId);
            if (institution == null)
            {
                ResponseHelper.ReturnNotFound("Institution not found");
            }

            institution.Name = name;    
            var entity = await base.UpdateAsync(institution);
            await this.Repository.SaveChanges();
            return entity;
        }
    }

}
