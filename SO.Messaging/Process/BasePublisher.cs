using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace  SO.Messaging.Process
{
    public class BasePublisher<T> : IBasePublisher<T>
    where T: class
    {
        private readonly IPublishEndpoint PublishEndpoint;
        public BasePublisher(IPublishEndpoint publishEndpoint)
        {
            PublishEndpoint = publishEndpoint;
        }

        public async Task Publish(T entity)
        {
            await PublishEndpoint.Publish<T>(entity);
        }
     
    }
}
