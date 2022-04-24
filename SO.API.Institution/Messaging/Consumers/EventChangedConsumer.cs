using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using SO.BusinessLayer.Institution.Entities.DTOs;
using SO.BusinessLayer.Institution.Services;
using SO.BusinessLayer.Messaging.Events;
using System.Threading.Tasks;

namespace SO.API.Institution.Messaging.Consumers
{
    public class EventChangedConsumer : IConsumer<IEvent2>
    {
        private readonly IUserService Service;
        public EventChangedConsumer(IUserService service)
        {
            Service = service;
        }

        public async Task Consume(ConsumeContext<IEvent2> context)
        {
            IEvent2 _event = context.Message;
            int a = 2;
        }
    }
}
