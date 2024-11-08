using E_Commerce.Domain.Productos;
using E_Commerce.Domain.Repository.Productos;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Repository.Productos
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category obj)
        {
            obj.Id = Guid.NewGuid();
            await _context.Categories.AddAsync(obj);
            return obj;
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> FindAllAsync()
        {
            IQueryable<Category> executeQuery = _context.Categories.AsNoTracking();
            List<Category> list = await executeQuery.ToListAsync();
            return list;
        }

        public Task<Category> FindByIdAsync(Guid id)
        {
            return FindByIdAsync(id, false);
        }

        public async Task<Category> FindByIdAsync(Guid id, bool tracking)
        {
            Category? category = await _context.Categories
                .AsTracking(tracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            return category;
        }

        public async Task RemoveAsync(Guid id)
        {
            Category? category =await _context.Categories
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (category == null)
            {
                throw new Exception("Category no found");
            }
            _context.Categories.Remove(category);
        }

        public Category Update(Category obj)
        {
            Category? category = _context.Categories.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            category.Name = obj.Name;
            return category;
        }
    }
}
