using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Institution.Entities.DTOs
{
    public class AddressDTO
    {
        public int InstitutionId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public InstitutionDTO Institution { get; set; }
    }
}
