using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SO.DataLayer.Institution.Model
{
    public partial class Institution
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid AdminId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
