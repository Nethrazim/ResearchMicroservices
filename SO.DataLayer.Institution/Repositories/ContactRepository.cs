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
    public class ContactRepository : GenericRepository<Contact, int>, IContactRepository
    {
        public ContactRepository(DbContext dbContext) : base(dbContext) { }
    }
}
