﻿using System;
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
    }
}