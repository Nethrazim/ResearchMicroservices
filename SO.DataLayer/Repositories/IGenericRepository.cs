using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.DataLayer.Repositories
{
    public interface IGenericRepository<T,TKey> where T : class
    {
        DbContext _dbContext { get; set; }
        T Get(TKey id);
        Task<T> CreateAsync(T entity);
        Task<List<T>> CreateAsync(List<T> entities);
        Task<bool> DeleteAsync(T id);
        Task<T> UpdateAsync(T entity);
        Task SaveChanges();
    }
}
