using SO.DataLayer.Identity.Repositories;
using SO.Messaging.Events.Identity;
using SO.Messaging.Process;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;

namespace SO.BusinessLayer.Identity.Services.Processes
{
    public interface IUserChangedPublishProcess : IBasePublishProcess<IUserChangedEvent>
    {
    }
}
