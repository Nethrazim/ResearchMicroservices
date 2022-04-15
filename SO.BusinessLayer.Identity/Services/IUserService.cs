using System;
using System.Collections.Generic;
using System.Text;
using SO.DataLayer.Identity.Model;
using System.Threading.Tasks;
using SO.BusinessLayer.Tokens;
using SO.BusinessLayer.Identity.Entities.DTOs;
namespace SO.BusinessLayer.Identity.Services
{
    public interface IUserService
    {
        Task<TokenDTO> AuthenticateAsync(string username, string password);
        Task<UserDTO> GetByUsernameAndPasswordAsync(string username, string password);
        Token GenerateToken(User user);
        Task<UserDTO> CreateUserAsync(string username, string email, string password, string role);
        Task<UserDTO> GetByEmail(string email);
    }
}
