using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SO.DataLayer.Repositories;
using SO.DataLayer.Teachers.Model;

namespace SO.DataLayer.Teachers.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher, int>, ITeacherRepository
    {
        public TeacherRepository(DbContext dbContext) : base(dbContext) { }
    }
}
