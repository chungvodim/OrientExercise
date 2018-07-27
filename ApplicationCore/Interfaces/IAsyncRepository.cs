using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<List<T>> ListAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity, bool saveChange = true);
        Task UpdateAsync(T entity, bool saveChange = true);
        Task DeleteAsync(T entity, bool saveChange = true);
        Task DeleteAsync(long id, bool saveChange = true);
        Task<int> SaveChangeAsync();
    }
}
