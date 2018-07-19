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
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<List<T>> ListAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
