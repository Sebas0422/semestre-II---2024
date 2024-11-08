using E_Commerce.Domain.Repository.Shared;
using E_Commerce.Domain.Usuarios;

namespace E_Commerce.Domain.Repository.Usuarios
{
    public interface IUserRepository : IRepository<User,Guid>
    {
    }
}
