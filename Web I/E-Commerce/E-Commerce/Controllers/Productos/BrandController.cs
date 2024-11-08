using E_Commerce.Domain.Productos;
using E_Commerce.Domain.Repository.Productos;
using E_Commerce.Domain.UnitOfWorkPattern;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers.Productos
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository _branRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BrandController(IBrandRepository branRepository, IUnitOfWork unitOfWork)
        {
            _branRepository = branRepository;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<List<Brand>> GetBrands()
        {
            return await _branRepository.FindAllAsync();
        }
        [HttpGet]
        public async Task<Brand> GetBrandById(Guid Id)
        {
            return await _branRepository.FindByIdAsync(Id);
        }

        [HttpPost]
        public async Task<Brand> CreateBrand([FromBody] Brand brand)
        {
            brand = await _branRepository.CreateAsync(brand);
            await _unitOfWork.Commit();
            return brand;
        }

        [HttpPut]
        public async Task<Brand> UpdateBrand([FromBody] Brand brand)
        {
            brand = _branRepository.Update(brand);
            await _unitOfWork.Commit();
            return brand;
        }

        [HttpDelete]
        public async Task RemoveBrand(Guid Id)
        {
            await _branRepository.RemoveAsync(Id);
            await _unitOfWork.Commit();
        }
    }
}
