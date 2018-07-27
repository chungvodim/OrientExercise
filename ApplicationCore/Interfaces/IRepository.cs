using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> GetDbSet();
        T GetById(long id);
        T GetSingleBySpec(ISpecification<T> spec);
        bool Any(Expression<Func<T, bool>> filter);
        IEnumerable<T> ListAll();
        IEnumerable<T> List(ISpecification<T> spec);
        IEnumerable<T> List(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        T SingleOrDefaul(Expression<Func<T, bool>> filter);
        T FirstOrDefaul(Expression<Func<T, bool>> filter);
        T Add(T entity, bool saveChange = true);
        void Update(T entity, bool saveChange = true);
        void Delete(T entity, bool saveChange = true);
        void Delete(long id, bool saveChange = true);
        int SaveChange();
    }
}
