using E_Commerce.Domain.Imagen;
using E_Commerce.Domain.Repository.Shared;

namespace E_Commerce.Domain.Repository.Imagen
{
    public interface IImageRepository : IRepository<Image, Guid>
    {
    }
}
