using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly MyDbContext _dbContext;
        protected internal DbSet<T> _dbSet;
        public EfRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            this._dbSet = this._dbContext.Set<T>();
        }

        public DbSet<T> GetDbSet()
        {
            return this._dbSet;
        }

        public virtual T GetById(long id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await this._dbSet.AnyAsync(filter);
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return this._dbSet.Any(filter);
        }

        public IEnumerable<T> ListAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                            .Where(spec.Criteria)
                            .AsEnumerable();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = this._dbSet;
            if (filter != null)
            {
                query = query.Where<T>(filter);
            }

            return (orderBy == null ? query.ToList<T>() : orderBy(query).ToList<T>());
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                            .Where(spec.Criteria)
                            .ToListAsync();
        }

        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = this._dbSet;
            if (filter != null)
            {
                query = query.Where<T>(filter);
            }

            return await (orderBy == null ? query.ToListAsync<T>() : orderBy(query).ToListAsync<T>());
        }

        public T Add(T entity, bool saveChange = true)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity, bool saveChange = true)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Update(T entity, bool saveChange = true)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity, bool saveChange = true)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity, bool saveChange = true)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity, bool saveChange = true)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id, bool saveChange = true)
        {
            var entity = await GetByIdAsync(id);
            await DeleteAsync(entity);
        }

        public void Delete(long id, bool saveChange = true)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public int SaveChange()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            return await this._dbSet.SingleOrDefaultAsync(filter);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            return await this._dbSet.FirstOrDefaultAsync(filter);
        }

        public T SingleOrDefaul(Expression<Func<T, bool>> filter)
        {
            return this._dbSet.FirstOrDefault(filter);
        }

        public T FirstOrDefaul(Expression<Func<T, bool>> filter)
        {
            return this._dbSet.FirstOrDefault(filter);
        }
    }
}
