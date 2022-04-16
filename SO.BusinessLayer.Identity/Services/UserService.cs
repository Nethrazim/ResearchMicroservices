﻿using System;
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
using SO.BusinessLayer.Helpers;

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
            var userByUsername = await Repository.GetByUsername(username);
            if (userByUsername == null)
            {
                ResponseHelper.ReturnNotFound("User not found");
            }

            return Mapper.Map<UserDTO>(await Repository.GetByUsernameAndPasswordAsync(username, PasswordHelper.GeneratePassword(password, userByUsername.Salt)));
        }

        public Token GenerateToken(User user)
        {
            return TokenHelper.Generate(user, Configuration);
        }

        public async Task<UserDTO> CreateUserAsync(string username, string email, string password, string role)
        {
            UserDTO checkUser = await GetByEmail(email);
            if (checkUser != null)
            {
                ResponseHelper.ReturnBadRequest("Email already in use");
            }

            checkUser = await GetByUsername(username);
            if (checkUser != null)
            {
                ResponseHelper.ReturnBadRequest("Username already in use");
            }

            string salt = PasswordHelper.GenerateSalt();
            string hashedPassword = PasswordHelper.GeneratePassword(password, salt);

            UserDTO newUser = Mapper.Map<UserDTO>(await Repository.CreateAsync(new User() { Username = username, Password = hashedPassword, Role = role, Email = email, Salt = salt }));

            await Repository.SaveChanges();
            return newUser;
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            UserDTO user = Mapper.Map<UserDTO>(await Repository.GetByEmail(email));
            return user;
        }

        public async Task<UserDTO> GetByUsername(string username)
        {
            UserDTO user = Mapper.Map<UserDTO>(await Repository.GetByUsername(username));
            return user;
        }
    }
}
