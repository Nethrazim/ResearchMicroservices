using System;
using System.Collections.Generic;
using System.Text;

namespace SO.API.Identity.Entities.Requests
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set;}
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
