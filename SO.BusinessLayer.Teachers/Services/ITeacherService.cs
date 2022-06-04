using SO.BusinessLayer.Services;
using SO.BusinessLayer.Teachers.Entities.DTOs;
using SO.DataLayer.Teachers.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.BusinessLayer.Teachers.Services
{
    public interface ITeacherService : IGenericService<TeacherDTO, Teacher, int>
    {
        Task<(List<TeacherDTO> teachers, int totalCount)> GetTeachersByInstitutionId(int pageIndex, int pageSize, int institutionId, string firstName, string middleName, string lastName);
    }
}
