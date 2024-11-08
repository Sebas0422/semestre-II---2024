using E_Commerce.Domain.Repository.Usuarios;
using E_Commerce.Domain.Usuarios;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Repository.Usuarios
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User obj)
        {
            obj.Id = Guid.NewGuid();
            _context.Entry(obj.Role).State = EntityState.Unchanged;
            await _context.Users.AddAsync(obj);
            return obj;
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> FindAllAsync()
        {
            IQueryable<User> executeQuery = _context.Users.AsNoTracking();
            List<User> list = await executeQuery.ToListAsync();
            return list;
        }

        public Task<User> FindByIdAsync(Guid id)
        {
            return FindByIdAsync(id, false);
        }

        public async Task<User> FindByIdAsync(Guid id, bool tracking)
        {
            User? user = await _context.Users
                .Include(x=> x.Role)
                .AsTracking(tracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task RemoveAsync(Guid id)
        {
            User? user = await _context.Users
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(user);
        }

        public User Update(User obj)
        {
            User? user = _context.Users
                .Include(x => x.Role)
                .FirstOrDefault(x => x.Id.Equals(obj.Id));
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.FullName= obj.FullName;
            user.Email = obj.Email;
            user.Password = obj.Password;
            user.Role = obj.Role;
            return user;
        }
    }
}
