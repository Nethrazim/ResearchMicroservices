using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SO.DataLayer.Identity.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SO.DataLayer.Repositories;

namespace SO.DataLayer.Identity.Repositories
{
    public class UserRepository : GenericRepository<User, int> , IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return await _dbContext.Set<User>().Where(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
        }


    }
}
