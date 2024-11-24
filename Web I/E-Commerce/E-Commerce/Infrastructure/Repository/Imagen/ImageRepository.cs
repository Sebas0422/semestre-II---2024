using E_Commerce.Domain.Imagen;
using E_Commerce.Domain.Repository.Imagen;

namespace E_Commerce.Infrastructure.Repository.Imagen
{
    public class ImageRepository : IImageRepository
    {
        private readonly 
        public Task<Image> CreateAsync(Image obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Image>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Image> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Image> FindByIdAsync(Guid id, bool tracking)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Image Update(Image obj)
        {
            throw new NotImplementedException();
        }
    }
}
