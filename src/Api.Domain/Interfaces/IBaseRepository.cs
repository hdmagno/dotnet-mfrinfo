using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entity;

namespace Api.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity, Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
    }
}
