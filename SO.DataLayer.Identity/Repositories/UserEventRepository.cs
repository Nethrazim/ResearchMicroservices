using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SO.DataLayer.Identity.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SO.DataLayer.Repositories;
using SO.Messaging.Events.Identity;

namespace SO.DataLayer.Identity.Repositories
{
    public class UserEventRepository: IUserEventRepository
    {
        private DbContext _dbContext;
        public UserEventRepository() 
        {
            _dbContext = new IdentityContext();
        }

        public async Task<List<User>> GetEventsToPublish()
        {
            _dbContext = new IdentityContext();
            var users = await _dbContext.Set<User>().Where(u => u.IsPublished == false).ToListAsync(); 
            return users;
        }

        public async Task UpdateEventsAsPublished(List<IUserChangedEvent> events)
        {
            _dbContext = new IdentityContext();
            foreach (var ev in events)
            {
                var user = await _dbContext.Set<User>().Where(user => user.Id == ev.Id).FirstOrDefaultAsync();
            
                user.IsPublished = true;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
