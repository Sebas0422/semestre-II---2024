using E_Commerce.Domain.Repository.Shared;
using E_Commerce.Domain.Usuarios;

namespace E_Commerce.Domain.Repository.Usuarios
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {
    }
}
