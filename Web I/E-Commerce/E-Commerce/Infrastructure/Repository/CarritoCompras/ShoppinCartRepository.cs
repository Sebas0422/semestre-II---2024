using E_Commerce.Domain.CarritoCompras;
using E_Commerce.Domain.Repository.CarritoCompras;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Repository.CarritoCompras
{
    public class ShoppinCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;

        public ShoppinCartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ShoppingCart> CreateAsync(ShoppingCart obj)
        {
            obj.Id = Guid.NewGuid();
            _context.Entry(obj.User).State = EntityState.Unchanged;
            await _context.ShoppingCarts.AddAsync(obj);
            return obj;
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ShoppingCart>> FindAllAsync()
        {
            IQueryable<ShoppingCart> executeQuery = _context.ShoppingCarts.AsNoTracking().Include(x=> x.User).Include(x=> x.Orders);
            List<ShoppingCart> list = await executeQuery.ToListAsync();
            return list;
        }

        public Task<ShoppingCart> FindByIdAsync(Guid id)
        {
            return FindByIdAsync(id, false);
        }

        public async Task<ShoppingCart> FindByIdAsync(Guid id, bool tracking)
        {
            ShoppingCart? shoppingCart = await _context.ShoppingCarts
                .Include(x => x.User)
                .Include(x => x.Orders)
                .AsTracking(tracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (shoppingCart == null)
            {
                throw new Exception("Shoppin Cart not found");
            }
            return shoppingCart;
        }

        public async Task RemoveAsync(Guid id)
        {
            ShoppingCart? shoppingCart = await _context.ShoppingCarts
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (shoppingCart == null)
            {
                throw new Exception("Shoppin Cart not found");
            }
            _context.ShoppingCarts.Remove(shoppingCart);
        }

        public ShoppingCart Update(ShoppingCart obj)
        {
            ShoppingCart? shoppingCart = _context.ShoppingCarts
                .AsTracking()
                .FirstOrDefault(x => x.Id.Equals(obj.Id));
            if (shoppingCart == null)
            { throw new Exception("Shopping cart not found"); }
            shoppingCart = obj;
            return shoppingCart;
        }
    }
}
