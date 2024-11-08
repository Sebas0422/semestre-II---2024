using E_Commerce.Domain.Repository.Shared;
using E_Commerce.Domain.CarritoCompras;

namespace E_Commerce.Domain.Repository.CarritoCompras
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
    }
}
