using System;
using System.ComponentModel.DataAnnotations;

namespace SO.API.Institution.Model.Requests
{
    public class CreateInstitutionRequest
    {
        [Required]
        public Guid AdminId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
