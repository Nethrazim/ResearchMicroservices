using System;
using System.Collections.Generic;
using System.Text;

namespace BaseClientNS.Entities.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string IsLockedOut { get; set; }
    }
}
