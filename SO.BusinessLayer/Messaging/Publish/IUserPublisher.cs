using SO.BusinessLayer.Messaging.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Messaging.Publish
{
    public interface IUserPublisher : IBasePublisher<IUserChangedEvent>
    {

    }
}
