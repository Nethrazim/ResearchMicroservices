using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using SO.DataLayer.Identity.Repositories;
using SO.DataLayer.Identity.Model;
using System.Threading.Tasks;
using SO.BusinessLayer.Identity.Entities.DTOs;
using SO.BusinessLayer.Tokens;
using SO.BusinessLayer.Identity.Helpers;
using SO.API.Helpers;
using Microsoft.Extensions.Configuration;
using SO.BusinessLayer.Services;

namespace SO.BusinessLayer.Identity.Services
{
    public class UserService : GenericService<IUserRepository, User, int>, IUserService
    {
        private IMapper Mapper;
        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration): base(userRepository, configuration)
        {
            Mapper = mapper;
        }

        public async Task<TokenDTO> AuthenticateAsync(string username, string password) {
            UserDTO user = await GetByUsernameAndPasswordAsync(username, password);
            if (user == null)
            {
                ResponseHelper.ReturnNotFound("User not found.");
            }

            Token token = GenerateToken(Mapper.Map<User>(user));
            return Mapper.Map<TokenDTO>(token);
        }

        public async Task<UserDTO> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return Mapper.Map<UserDTO>(await Repository.GetByUsernameAndPasswordAsync(username, password));
        }

        public Token GenerateToken(User user)
        {
            return TokenHelper.Generate(user, Configuration);
        }

        public async Task<UserDTO> CreateUserAsync(string username, string email, string password, string role)
        {
            UserDTO newUser = Mapper.Map<UserDTO>(await Repository.CreateAsync(new User() { Username = username, Password = password, Role = role, Email = email }));
            await Repository.SaveChanges();
            return newUser;
        }
    }
}
