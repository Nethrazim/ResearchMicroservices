using MassTransit;
using SO.BusinessLayer.Messaging.Events;
using System.Threading.Tasks;

namespace SO.API.Institution.Messaging.Consumers
{
    public class UserChangedConsumer : IConsumer<IUserChangedEvent>
    {
        public async Task Consume(ConsumeContext<IUserChangedEvent> context)
        {
            int a = 2;
        }
    }
}
