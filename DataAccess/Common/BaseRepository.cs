using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Utilities.GenericQuery;
using Utilities.Objects;

namespace DataAccess.Common
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        public readonly MainContext context;

        protected BaseRepository(MainContext context)
        {
            this.context = context;
        }

        public MainContext GetContext()
        {
            return context;
        }

        public async Task<int?> CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);

            if (entity is null) return false;

            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public async Task<List<T>> SearchAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().Where(expression).ToListAsync();
        }
        public async Task<T?> FindAsync(Expression<Func<T, bool>> expression)
        {
            var result = await context.Set<T>().FirstOrDefaultAsync(expression);
            return result is null ? null : result;
        }

        public IQueryable<T> Query(IQueryable<T> IQuery, Query query)
        {
            IQuery = IQuery.OrderByGeneric(query.Sort);
            IQuery = IQuery.FilterGeneric(query.Filters);
            IQuery = IQuery.Page(query.Page);
            return IQuery;
        }

        public async Task<int> QueryCount(IQueryable<T> IQuery, Query query)
        {
            IQuery = IQuery.FilterGeneric(query.Filters);
            return await IQuery.CountAsync();
        }
    }

}
