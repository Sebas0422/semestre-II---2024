using E_Commerce.Domain.CarritoCompras;
using E_Commerce.Domain.Repository.CarritoCompras;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Repository.CarritoCompras
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(Order obj)
        {
            obj.Id = Guid.NewGuid();
            await _context.Ordes.AddAsync(obj);
            return obj;
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> FindAllAsync()
        {
            IQueryable<Order> executeQuery = _context.Ordes.AsNoTracking();
            List<Order> list = await executeQuery.ToListAsync();
            return list;
        }

        public Task<Order> FindByIdAsync(Guid id)
        {
            return FindByIdAsync(id, false);
        }

        public async Task<Order> FindByIdAsync(Guid id, bool tracking)
        {
            Order? order = await _context.Ordes
                .AsTracking(tracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            return order;
        }

        public async Task RemoveAsync(Guid id)
        {
            Order? order = await _context.Ordes
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            _context.Ordes.Remove(order);
        }

        public Order Update(Order obj)
        {
            Order? order = _context.Ordes
                .FirstOrDefault(x => x.Id.Equals(obj.Id));
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            order = obj;
            return order;
        }
    }
}
