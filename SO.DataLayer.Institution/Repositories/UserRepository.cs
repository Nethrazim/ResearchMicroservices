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
    public class UserRepository : GenericRepository<Institution.Model.User, int>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }
    }
}
