using SO.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Address = SO.DataLayer.Institution.Model.Address;

namespace SO.DataLayer.Institution.Repositories
{
    public interface IAddressRepository : IGenericRepository<Address, int>
    {
        Task<Address> GetByInstitutionId(int institutionId);
    }
}
