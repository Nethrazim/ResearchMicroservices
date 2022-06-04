using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SO.DataLayer.Repositories;
using SO.DataLayer.Teachers.Model;

namespace SO.DataLayer.Teachers.Repositories
{
    public interface ITeacherRepository : IGenericRepository<Teacher,int>
    {
        Task<(List<Teacher> teachers, int totalCount)> GetTeachersByInstitutionId(int pageIndex, int pageSize, int institutionId, string firstName, string middleName, string lastName);
    }
}
