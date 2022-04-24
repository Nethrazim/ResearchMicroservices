using MassTransit;
using SO.BusinessLayer.Messaging.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Messaging.Publish
{
    public class UserPublisher : BasePublisher<IUserChangedEvent>, IUserPublisher
    {
        private readonly IPublishEndpoint PublishEndpoint;
        public UserPublisher(IPublishEndpoint publishEndpoint) : base(publishEndpoint)
        {
        }
    }
}
