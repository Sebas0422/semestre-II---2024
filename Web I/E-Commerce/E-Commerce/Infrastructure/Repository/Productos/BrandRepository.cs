using E_Commerce.Domain.Productos;
using E_Commerce.Domain.Repository.Productos;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Repository.Productos
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Brand> CreateAsync(Brand obj)
        {
            obj.Id = Guid.NewGuid();
            await _context.Brands.AddAsync(obj);
            return obj;
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Brand>> FindAllAsync()
        {
            IQueryable<Brand>  executeQuery = _context.Brands.AsNoTracking();
            List<Brand> list = await executeQuery.ToListAsync();
            return list;
        }

        public Task<Brand> FindByIdAsync(Guid id)
        {
            return FindByIdAsync(id, false);
        }

        public async Task<Brand> FindByIdAsync(Guid id, bool tracking)
        {
            Brand? brand = await _context.Brands
                .AsTracking(tracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (brand == null)
            {
                throw new Exception("Brand not found");
            }
            return brand;
        }

        public async Task RemoveAsync(Guid id)
        {
            Brand? brand = await _context.Brands
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (brand == null)
            {
                throw new Exception("Brand not found");
            }
            _context.Brands.Remove(brand);
        }

        public Brand Update(Brand obj)
        {
            Brand? brand = _context.Brands.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if (brand == null)
            {
                throw new Exception("Brand not found");
            }
            brand.Name = obj.Name;
            return brand;
        }
    }
}
