using System;
using System.ComponentModel.DataAnnotations;

namespace SO.API.Institution.Model.Requests
{
    public class UpdateAddressRequest
    {
        [Required]
        public int InstitutionId { get; set; }

        [Required]
        [StringLength(255)]
        public string Address1 { get; set; }

        [Required]
        [StringLength(255)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        public string State { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Zip { get; set; }
    }
}
