using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Restaurant_Website.Domain.Interfaces
{
    public interface IRepositoty<T> : IDisposable 
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<bool> ContainsAsync(T item);

        void Insert(T item);
        Task InsertAsync(T item);
        Task InsertRangeAsync(IEnumerable<T> items);
        void Update(T item);
        void Delete(T item);
        void Delete(object id);
        void DeleteRange(IEnumerable<T> range);
    }
}
