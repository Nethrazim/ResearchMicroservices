using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Institution.Entities.DTOs
{
    public class ContactDTO
    {
        public int InstitutionId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public InstitutionDTO Institution { get; set; }
    }
}
