using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Messaging.Events.Identity
{
    public interface IUserChangedEvent
    {
        public int Id { get; }
        public string Username { get; }
        public string Email { get;}
        public int Role { get; }
        public Guid SystemUserId { get; }
    }
}
