using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Institution.Entities.DTOs
{
    public class InstitutionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid AdminId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
