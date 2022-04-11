using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.DataLayer.Repositories
{
    public class GenericRepository<T,Tkey> : IGenericRepository<T, Tkey> where T : class
    {
        public DbContext _dbContext { get; set; }

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Get(Tkey id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task<List<T>> CreateAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return true;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return entity;
        }

        public Task<List<T>> UpdateAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
