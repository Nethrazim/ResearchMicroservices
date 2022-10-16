using System;
using System.Collections.Generic;
using System.Text;
using SO.DataLayer.Identity.Model;
using System.Threading.Tasks;
using SO.DataLayer.Repositories;
using SO.Messaging.Events.Identity;

namespace SO.DataLayer.Identity.Repositories
{
    public interface IUserEventRepository
    {
        Task<List<User>> GetEventsToPublish();
        Task UpdateEventsAsPublished(List<IUserChangedEvent> events);
    }
}
