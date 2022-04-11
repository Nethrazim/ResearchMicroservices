using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SO.BusinessLayer.Tokens
{
    public class Token
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string TokenValue { get; set; }
        public long Expires { get; set; }
    }
}
