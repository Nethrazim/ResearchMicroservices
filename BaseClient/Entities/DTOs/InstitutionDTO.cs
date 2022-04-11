using BaseClientNS.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseClientNS.Entities.DTOs
{
    public class InstitutionDTO : TokenProvider
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Guid? UserId { get; set; }
        public long? CurrentSchoolYearId { get; set; }
        public InstitutionAddressDTO InstitutionAddress { get; set; }
        public List<SchoolYearDTO> SchoolYears { get; set; }
        public SchoolYearDTO CurrentSchoolYear { get; set; }
    }
}
