using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Messaging.Events
{
    public interface IUserChangedEvent
    {
        public int Id { get; }
        public string Username { get; }
        public string Email { get;}
        public string Password { get;}
        public int Role { get; }
        public bool IsLockedOut { get; }
        public Guid SystemUserId { get; }
    }
}
