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
    public class AddressRepository : GenericRepository<Address, int>, IAddressRepository
    {
        public AddressRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<Address> GetByInstitutionId(int institutionId)
        {
            return await Task.FromResult(this._dbContext.Set<Address>().FirstOrDefault(a => a.InstitutionId == institutionId));
        }
    }
}
