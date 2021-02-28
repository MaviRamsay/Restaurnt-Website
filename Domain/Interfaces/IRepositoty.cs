using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Restaurant_Website.Domain.Interfaces
{
    public interface IRepositoty<T> : IDisposable 
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                            string includeProperties = "");
        void Insert(T item);
        Task InsertAsync(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(object id);
    }
}
