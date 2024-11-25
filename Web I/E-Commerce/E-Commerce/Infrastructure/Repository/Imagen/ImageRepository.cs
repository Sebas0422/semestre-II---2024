using E_Commerce.Domain.Imagen;
using E_Commerce.Domain.Repository.Imagen;
using E_Commerce.Domain.UnitOfWorkPattern;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Repository.Imagen
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ImageRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Image> CreateAsync(Image obj)
        {
            await _context.Images.AddAsync(obj);
            await _unitOfWork.Commit();
            return obj;
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Image>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Image> FindByIdAsync(int id)
        {
            return await FindByIdAsync(id, false);
        }

        public async Task<Image> FindByIdAsync(int id, bool tracking)
        {
            Image? image = await _context.Images
                .AsTracking(tracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                .FirstOrDefaultAsync(x => x.ImagenId.Equals(id));
            return image;
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Image Update(Image obj)
        {
            throw new NotImplementedException();
        }
    }
}
