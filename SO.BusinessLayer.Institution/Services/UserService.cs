using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SO.BusinessLayer.Services;
using SO.BusinessLayer.Institution.Entities.DTOs;
using SO.DataLayer.Institution.Repositories;
using SO.BusinessLayer.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using SO.API.Helpers;

namespace SO.BusinessLayer.Institution.Services
{
    public class UserService : GenericService<IUserRepository, UserDTO,SO.DataLayer.Institution.Model.User,int>, IUserService
    {
        public UserService(IUserRepository repository, IMapper mapper, IConfiguration configuration)
            : base(repository, configuration, mapper)
        {
        }

        public async Task<UserDTO> PatchAsync(UserDTO user)
        {
            UserDTO patchedUser = null;

            if (this.Repository.Get(user.Id) != null)
            {
                patchedUser = Mapper.Map<UserDTO>(await this.Repository.UpdateAsync(Mapper.Map<SO.DataLayer.Institution.Model.User>(user)));
            }
            else
            {
                patchedUser = Mapper.Map<UserDTO>(await this.Repository.CreateAsync(Mapper.Map<SO.DataLayer.Institution.Model.User>(user)));
            }
            
            await Repository.SaveChanges();
            return patchedUser;
        }
    }

}
