
namespace E_Commerce.Domain.Repository.Shared
{
    public interface IRepository<T,Id>
    {
        Task<bool> ExistsAsync(Id id);
        Task<T> CreateAsync(T obj);
        T Update(T obj);
        Task RemoveAsync(Id id);
        Task<T> FindByIdAsync(Id id);
        Task<T> FindByIdAsync(Id id, bool tracking);
        Task<List<T>> FindAllAsync();
    }
}
