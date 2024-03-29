﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SO.BusinessLayer.DataReference.Users;

namespace SO.BusinessLayer.Identity.Entities.DTOs
{
    public class TokenDTO
    {
        [JsonProperty("Username")]
        public string Username { get; set; }
        
        [JsonProperty("Email")]
        public string Email { get; set; }
        
        [JsonProperty("TokenValue")]
        public string TokenValue { get; set; }

        [JsonProperty("Expires")]
        public long Expires { get; set; }

        [JsonProperty("Role")]
        public UserRoles Role { get; set; }

        [JsonProperty("SystemUserId")]
        public Guid SystemUserId { get; set; }
    }
}
