using E_Commerce.Domain.Productos;
using E_Commerce.Domain.Repository.Productos;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Repository.Productos
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Article> CreateAsync(Article obj)
        {
            obj.Id = Guid.NewGuid();
            _context.Entry(obj.Brand).State = EntityState.Unchanged;
            await _context.Articles.AddAsync(obj);
            return obj;
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Article>> FindAllAsync()
        {
            IQueryable<Article> executeQuery= _context.Articles.AsNoTracking().Include(x=> x.Brand);
            List<Article> list = await executeQuery.ToListAsync();
            return list;
        }

        public Task<Article> FindByIdAsync(Guid id)
        {
            return FindByIdAsync(id, false);
        }

        public async Task<Article> FindByIdAsync(Guid id, bool tracking)
        {
            Article? article = await _context.Articles
                .Include(x=> x.Brand)
                .AsTracking(tracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if(article == null)
            {
                throw new Exception("Article not found");
            }
            return article;
        }

        public async Task RemoveAsync(Guid id)
        {
            Article? article = await _context.Articles
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (article == null)
            {
                throw new Exception("Article not found");
            }
            _context.Articles.Remove(article);
        }

        public Article Update(Article obj)
        {
            Article? article = _context.Articles.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if(article == null)
            {
                throw new Exception("Article not found");
            }
            article.Name = obj.Name;
            article.Description = obj.Description;
            article.Price = obj.Price;
            article.Brand = obj.Brand;
            article.Categories = obj.Categories;
            return article;

        }
    }
}
