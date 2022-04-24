using System;
using System.Collections.Generic;
using System.Text;
using SO.DataLayer.Repositories;
using SO.DataLayer.Institution.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace SO.DataLayer.Institution.Repositories
{
    public class InstitutionRepository : GenericRepository<Institution.Model.Institution, int>, IInstitutionRepository
    {
        public InstitutionRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<Institution.Model.Institution> GetByName(string name)
        {
            return await _dbContext.Set<Institution.Model.Institution>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Institution.Model.Institution> GetByAdminId(Guid adminId)
        {
            return await _dbContext.Set<Institution.Model.Institution>().Where(i => i.AdminId == adminId).FirstOrDefaultAsync();
        }
    }
}
