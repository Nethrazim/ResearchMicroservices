using System;
using System.ComponentModel.DataAnnotations;

namespace SO.API.Institution.Model.Requests
{
    public class GetContactByInstitutionIdRequest
    {
        [Required]
        public int InstitutionId { get; set; }
    }
}
