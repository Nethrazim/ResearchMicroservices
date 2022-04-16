using System.ComponentModel.DataAnnotations;

namespace SO.API.Identity.Model.Requests
{
    public class ChangePasswordRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
