using AutoMapper;
using Microsoft.Extensions.Configuration;
using SO.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace SO.BusinessLayer.Services
{
    public class GenericService<TRepository, TEntityDTO, TEntity, TKey> 
        where TRepository : IGenericRepository<TEntity, TKey> 
        where TEntityDTO : class
        where TEntity: class
        where TKey : struct
    {
        public IMapper Mapper;
        public TRepository Repository { get; set; }
        public IConfiguration Configuration { get; set; }
        public GenericService(TRepository repository, IConfiguration configuration, IMapper mapper)
        {
            Repository = repository;
            Configuration = configuration;
            Mapper = mapper;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            TEntity entity = Repository.Get(id);
            bool result = await Repository.DeleteAsync(entity);
            await Repository.SaveChanges();
            return result;
        }

        public Task<TEntityDTO> GetById(TKey id)
        {
            return Task.FromResult(Mapper.Map<TEntityDTO>(Repository.Get(id)));
        }

        public async Task<TEntityDTO> UpdateAsync(TEntityDTO entity)
        {
            return Mapper.Map<TEntityDTO>(await Repository.UpdateAsync(Mapper.Map<TEntity>(entity)));
        }

        public async Task<TEntityDTO> CreateAsync(TEntityDTO entity)
        {
            var result = Mapper.Map<TEntityDTO>(await Repository.CreateAsync(Mapper.Map<TEntity>(entity)));
            await Repository.SaveChanges();
            return result;
        }
    }
}
