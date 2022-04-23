using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using SO.BusinessLayer.Institution.Entities.DTOs;
using SO.BusinessLayer.Institution.Services;
using SO.BusinessLayer.Messaging.Events;
using System.Threading.Tasks;

namespace SO.API.Institution.Messaging.Consumers
{
    public class UserChangedConsumer : IConsumer<IUserChangedEvent>
    {
        private readonly IUserService Service;
        public UserChangedConsumer(IUserService service)
        {
            Service = service;
        }

        public async Task Consume(ConsumeContext<IUserChangedEvent> context)
        {
            IUserChangedEvent _event = context.Message;
            await Service.PatchAsync(GetUser(_event));
        }

        public UserDTO GetUser(IUserChangedEvent _event)
        {
            UserDTO user = new UserDTO()
            {
                Email = _event.Email,
                Id = _event.Id,
                Role = _event.Role,
                SystemUserId = _event.SystemUserId,
                Username = _event.Username
            };

            return user;
        }
    }
}
