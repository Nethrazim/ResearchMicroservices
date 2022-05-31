using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Teachers.Entities.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public int InstitutionId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
    }
}
