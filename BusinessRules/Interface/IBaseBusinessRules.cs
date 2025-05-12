using Utilities.Objects;

namespace BusinessRules.Interface
{
    public interface IBaseBusinessRules<T> where T : class, new()
    {
        Task<int?> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<CustomList<T>> Query(Query query);
    }
}
