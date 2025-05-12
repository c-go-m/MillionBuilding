using DataAccess.Common;
using System.Linq.Expressions;
using Utilities.Objects;

namespace DataAccess.Interface
{
    public interface IBaseRepository<T> where T : class, new()
    {
        MainContext GetContext();
        Task<int?> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> SearchAsync(Expression<Func<T, bool>> expression);
        Task<T?> FindAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> Query(IQueryable<T> IQuery, Query query);
        Task<int> QueryCount(IQueryable<T> IQuery, Query query);
    }
}
