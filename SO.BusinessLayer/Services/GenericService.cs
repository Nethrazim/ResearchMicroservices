using SO.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace SO.BusinessLayer.Services
{
    public class GenericService<TRepository, TEntity, TKey> where TRepository : IGenericRepository<TEntity, TKey> where TEntity : class where TKey : struct
    {
        public TRepository Repository { get; set; }
        public GenericService(TRepository repository)
        {
            Repository = repository;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            TEntity entity = Repository.Get(id);
            bool result = await Repository.DeleteAsync(entity);
            await Repository.SaveChanges();
            return result;
        }
    }
}
