using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.BusinessLayer.Services
{
    public interface IGenericService<TEntityDTO, TEntity, TKey>
        where TEntityDTO : class
        where TEntity : class
        where TKey : struct
    {

        Task<bool> DeleteAsync(TKey id);
        Task<TEntityDTO> GetById(TKey id);
        Task<TEntityDTO> UpdateAsync(TEntityDTO entity);
    }
}
