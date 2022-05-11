﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SO.BusinessLayer.Institution.Entities.DTOs;
namespace SO.BusinessLayer.Institution.Services
{
    public interface IUserService
    {
        Task<UserDTO> PatchAsync(UserDTO user);
    }
}