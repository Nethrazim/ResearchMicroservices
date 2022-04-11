using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClientNS.Entities.DTOs
{
    public class InstitutionAddressDTO
    {
        public long InstitutionId { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
    }
}
