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

namespace SO.BusinessLayer.Identity.Services
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; set; }
        private IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.UserRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<TokenDTO> AuthenticateAsync(string username, string password) {
            UserDTO user = await GetByUsernameAndPasswordAsync(username, password);
            Token token = null;

            if (user != null)
            {
                token = GenerateToken(_mapper.Map<User>(user));
            }

            return _mapper.Map<TokenDTO>(token);
        }

        public async Task<UserDTO> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return _mapper.Map<UserDTO>(await UserRepository.GetByUsernameAndPasswordAsync(username, password));
        }

        public Token GenerateToken(User user)
        {
            return TokenHelper.Generate(user);
        }

        public async Task<UserDTO> CreateUserAsync(string username, string email, string password, string role)
        {
            UserDTO newUser = _mapper.Map<UserDTO>(await UserRepository.CreateAsync(new User() { Username = username, Password = password, Role = role, Email = email }));
            await UserRepository.SaveChanges();
            return newUser;
        }
    }
}
