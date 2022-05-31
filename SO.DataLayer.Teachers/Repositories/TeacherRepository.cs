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

        public async Task<List<Teacher>> GetTeachersByInstitutionId(int pageIndex, int pageSize, int institutionId)
        {
            return await _dbContext.Set<Teacher>().Where(t => t.InstitutionId == institutionId).Skip((pageIndex -1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
