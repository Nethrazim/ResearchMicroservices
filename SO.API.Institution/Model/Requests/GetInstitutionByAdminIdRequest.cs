using System;
using System.ComponentModel.DataAnnotations;

namespace SO.API.Institution.Model.Requests
{
    public class GetInstitutionByAdminIdRequest
    {
        [Required]
        public Guid AdminId { get; set; }
    }
}
