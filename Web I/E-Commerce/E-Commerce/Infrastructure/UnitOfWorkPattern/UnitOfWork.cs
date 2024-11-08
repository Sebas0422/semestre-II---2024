using E_Commerce.Domain.UnitOfWorkPattern;
using E_Commerce.Infrastructure.Data;

namespace E_Commerce.Infrastructure.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task Commit()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
