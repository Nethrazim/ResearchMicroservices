using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SO.BusinessLayer.Institution.Entities.DTOs;
using SO.BusinessLayer.Services;
using User = SO.DataLayer.Institution.Model.User;
namespace SO.BusinessLayer.Institution.Services
{
    public interface IUserService : IGenericService<UserDTO, User, int>
    {
        Task<UserDTO> PatchAsync(UserDTO user);
    }
}
