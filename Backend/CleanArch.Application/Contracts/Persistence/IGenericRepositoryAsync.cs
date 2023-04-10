using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Application.Contracts.Persistence
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task AddAsync(T entity);
        Task UpdateWithSaveChangesAsync(T entity);
        Task SaveChangesAsync();
        Task<T> AddAsyncWithSaveChangesAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
        IQueryable<T> GetQueryable();
        void DetachedEntry(T entry);
    }
}
