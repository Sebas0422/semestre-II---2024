using E_Commerce.Domain.CarritoCompras;
using E_Commerce.Domain.Repository.Shared;

namespace E_Commerce.Domain.Repository.CarritoCompras
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart, Guid>
    {
    }
}
