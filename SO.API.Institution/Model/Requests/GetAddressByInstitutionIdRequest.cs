using System;
using System.ComponentModel.DataAnnotations;

namespace SO.API.Institution.Model.Requests
{
    public class GetAddressByInstitutionIdRequest
    {
        [Required]
        public int InstitutionId { get; set; }
    }
}
