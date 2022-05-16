using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SO.BusinessLayer.Institution.Entities.DTOs;
using SO.BusinessLayer.Services;

namespace SO.BusinessLayer.Institution.Services
{
    public interface IInstitutionService : IGenericService<InstitutionDTO, DataLayer.Institution.Model.Institution, int>
    {   
        Task<InstitutionDTO> CreateInstitutionAsync(string name, Guid adminId);
        Task<InstitutionDTO> GetByName(string name);
        Task<InstitutionDTO> GetByAdminId(Guid adminId);
        Task<bool> DeleteAsync(int institutionId);
        Task<InstitutionDTO> UpdateAsync(int institutionId, string name);
    }
}
