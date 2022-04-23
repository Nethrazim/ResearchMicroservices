using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.BusinessLayer.Messaging.Publish
{
    public class BasePublisher
    {
        private readonly IPublishEndpoint PublishEndpoint;
        public BasePublisher(IPublishEndpoint publishEndpoint)
        {
            PublishEndpoint = publishEndpoint;
        }

        public void Publish<T>(T entity) where T : class
        {
            PublishEndpoint.Publish<T>(entity);
        }
    }
}
