using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClientNS.Entities.Requests;

namespace BaseClientNS.Entities.DTOs
{
    public class SchoolYearDTO : TokenProvider
    {
        public long Id { get; set; }
        public long InstitutionId { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public bool IsMain { get; set; }
    }
}
