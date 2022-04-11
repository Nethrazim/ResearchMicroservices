using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BaseClientNS.Entities.DTOs
{
    public class TokenDTO
    {
        public string username { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public long expires { get; set; }
    }
}
