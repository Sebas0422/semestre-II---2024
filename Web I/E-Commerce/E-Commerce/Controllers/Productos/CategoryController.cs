using E_Commerce.Domain.Productos;
using E_Commerce.Domain.Repository.Productos;
using E_Commerce.Domain.UnitOfWorkPattern;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers.Productos
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<List<Category>> GetCategories()
        {
            return await _categoryRepository.FindAllAsync();
        }
        [HttpGet]
        public async Task<Category> GetCategoryById(Guid Id)
        {
            return await _categoryRepository.FindByIdAsync(Id);
        }

        [HttpPost]
        public async Task<Category> CreateCategory([FromBody] Category category)
        {
            category = await _categoryRepository.CreateAsync(category);
            await _unitOfWork.Commit();
            return category;
        }

        [HttpPut]
        public async Task<Category> UpdateCategory([FromBody] Category category)
        {
            category = _categoryRepository.Update(category);
            await _unitOfWork.Commit();
            return category;
        }

        [HttpDelete]
        public async Task RemoveCategory(Guid Id)
        {
            await _categoryRepository.RemoveAsync(Id);
            await _unitOfWork.Commit();
        }
    }
}
