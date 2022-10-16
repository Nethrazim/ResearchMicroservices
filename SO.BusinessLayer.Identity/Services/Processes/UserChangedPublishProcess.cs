using SO.DataLayer.Identity.Repositories;
using SO.Messaging.Events.Identity;
using SO.Messaging.Process;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using SO.BusinessLayer.Identity.Messaging;

namespace SO.BusinessLayer.Identity.Services.Processes
{
    public class UserChangedPublishProcess : BasePublishProcess<IUserChangedEvent>, IUserChangedPublishProcess
    {
        private readonly IUserEventRepository Repository;
        private static UserChangedPublishProcess _selfReference;
        public UserChangedPublishProcess(IUserEventRepository repository, IUserPublisher publisher, IMapper mapper) : base(publisher, mapper) 
        {
            Repository = repository;
            _selfReference = this;
        }
        
        public async override Task<List<IUserChangedEvent>> GetEventsToPublish()
        {
            return Mapper.Map<List<UserChanged>>(await Repository.GetEventsToPublish()).ConvertAll(o => (IUserChangedEvent)o);
        }

        public override async Task UpdateEventsAsPublished(List<IUserChangedEvent> events)
        {
            await Repository.UpdateEventsAsPublished(events);
        }
    }
}
