using System;
using System.Collections.Generic;
using System.Text;
using SO.DataLayer.Identity.Model;
using System.Threading.Tasks;
using SO.DataLayer.Repositories;

namespace SO.DataLayer.Identity.Repositories
{
    public interface IUserRepository : IGenericRepository<User,int>
    {
        Task<User> GetByUsernameAndPasswordAsync(string username, string password);
        Task<User> GetByEmail(string email);
        Task<User> GetByUsername(string username);
        Task<bool> ChangePasswordForStudentTeacher(string username, string password, string salt);
        Task<List<User>> GetEventsToPublish();
    }
}
