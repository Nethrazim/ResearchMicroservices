using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SO.DataLayer.Repositories;
using SO.DataLayer.Teachers.Model;

namespace SO.DataLayer.Teachers.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher, int>, ITeacherRepository
    {
        public TeacherRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<(List<Teacher> teachers, int totalCount)> GetTeachersByInstitutionId(int pageIndex, int pageSize, int institutionId, string firstName, string middleName, string lastName)
        {
            int totalCount = await _dbContext.Set<Teacher>().Where(t => t.InstitutionId == institutionId
                && (t.FirstName.Contains(firstName) || string.IsNullOrEmpty(firstName))
                && (t.LastName.Contains(lastName) || string.IsNullOrEmpty(lastName))
                && ( t.MiddleName.Contains(middleName) || string.IsNullOrEmpty(middleName))).CountAsync();

            return (await _dbContext.Set<Teacher>().Where(t => t.InstitutionId == institutionId 
                && (t.FirstName.Contains(firstName) || string.IsNullOrEmpty(firstName))
                && (t.LastName.Contains(lastName) || string.IsNullOrEmpty(lastName))
                && (t.MiddleName.Contains(middleName) || string.IsNullOrEmpty(middleName)))
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync(), totalCount);
        }
    }
}
