using SO.Messaging.Events.Identity;
using SO.Messaging.Process;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Identity.Messaging
{
    public interface IUserPublisher : IBasePublisher<IUserChangedEvent>
    {

    }
}
