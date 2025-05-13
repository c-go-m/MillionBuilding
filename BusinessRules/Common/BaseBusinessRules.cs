using BusinessRules.Interface;
using DataAccess.Interface;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Utilities.Objects;

namespace BusinessRules.Common
{
    public abstract class BaseBusinessRules<T, TRepository> : IBaseBusinessRules<T>
        where T : BaseEntity, new()
        where TRepository : class, IBaseRepository<T>
    {

        protected readonly TRepository repository;
        protected BaseBusinessRules(TRepository repository)
        {
            this.repository = repository;
        }

        public virtual async Task<int?> CreateAsync(T entity)
        {
            entity.Id = 0;
            return await repository.CreateAsync(entity);
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            return await repository.UpdateAsync(entity);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public virtual async Task<CustomList<T>> Query(Query query)
        {
            var data = await repository.Query(repository.GetContext().Set<T>(), query).ToListAsync();
            var count = await repository.QueryCount(repository.GetContext().Set<T>(), query);
            var page = new PageList(query.Page, count);
            return new CustomList<T>(data, page);
        }
    }
}
