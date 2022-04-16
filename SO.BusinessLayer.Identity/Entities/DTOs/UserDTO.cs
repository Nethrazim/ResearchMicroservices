using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Identity.Entities.DTOs
{
    public class UserDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string Role { get; set; }
        [JsonIgnore]
        public bool IsLockedOut { get; set; }
        [JsonIgnore]
        public Guid SystemUserId { get; set; }
    }
}
