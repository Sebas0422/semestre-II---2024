using E_Commerce.Domain.Productos;
using E_Commerce.Domain.Repository.Shared;

namespace E_Commerce.Domain.Repository.Productos
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
    }
}
