using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SO.BusinessLayer.DataReference.Users;

namespace SO.API.Identity.Model.Requests
{
    public class CreateUserRequest : IValidatableObject
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public UserRoles Role { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Role == UserRoles.SuperAdmin)
            {
                results.Add(new ValidationResult("Invalid role for user."));
            }
            return results;
        }
    }

}
