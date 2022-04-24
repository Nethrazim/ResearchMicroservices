using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Messaging.Events
{
    public class UserChanged : IUserChangedEvent
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public Guid SystemUserId { get; set; }
    }
}
