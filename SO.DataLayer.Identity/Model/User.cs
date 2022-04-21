using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SO.DataLayer.Identity.Model
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Role { get; set; }
        public bool IsLockedOut { get; set; }
        public Guid SystemUserId { get; set; }
    }
}
