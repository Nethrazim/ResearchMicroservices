using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SO.DataLayer.Repositories
{
    public class GenericRepository<T,Tkey> : IGenericRepository<T, Tkey>
        where T : class
    {
        public DbContext _dbContext { get; set; }

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Get(Tkey id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            _dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<List<T>> CreateAsync(List<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await SaveChanges();
            return entities;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return true;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await SaveChanges();
            return entity;
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
