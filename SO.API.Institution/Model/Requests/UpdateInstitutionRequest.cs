using System;
using System.ComponentModel.DataAnnotations;

namespace SO.API.Institution.Model.Requests
{
    public class UpdateInstitutionRequest
    {
        public int InstitutionId { get; set; }
        public string Name { get; set; }
    }
}
