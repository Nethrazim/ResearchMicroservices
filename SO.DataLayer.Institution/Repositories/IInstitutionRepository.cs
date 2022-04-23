using SO.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.DataLayer.Institution.Repositories
{
    public interface IInstitutionRepository : IGenericRepository<SO.DataLayer.Institution.Model.Institution, int>
    {
        Task<Institution.Model.Institution> GetByName(string name);
    }
}
