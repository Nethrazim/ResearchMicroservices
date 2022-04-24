using SO.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.DataLayer.Institution.Repositories
{
    public interface IUserRepository : IGenericRepository<SO.DataLayer.Institution.Model.User, int>
    {
    }
}
