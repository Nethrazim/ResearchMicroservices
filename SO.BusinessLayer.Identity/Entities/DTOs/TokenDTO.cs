using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Identity.Entities.DTOs
{
    public class TokenDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string TokenValue { get; set; }
        public long Expires { get; set; }
    }
}
