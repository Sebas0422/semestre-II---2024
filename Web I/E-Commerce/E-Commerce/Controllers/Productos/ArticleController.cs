using E_Commerce.Domain.Productos;
using E_Commerce.Domain.Repository.Productos;
using E_Commerce.Domain.UnitOfWorkPattern;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers.Productos
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleController(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Article>> GetArticles()
        {
            return await _articleRepository.FindAllAsync();
        }

        [HttpGet]
        public async Task<Article> GetArticleById(Guid Id)
        {
            return await _articleRepository.FindByIdAsync(Id);
        }

        [HttpPost]
        public async Task<Article> CreateArticle([FromBody]Article article)
        {
            article = await _articleRepository.CreateAsync(article);
            await _unitOfWork.Commit();
            return article;
        }

        [HttpPut]
        public async Task<Article> UpdateArticle ([FromBody]Article article)
        {
            article = _articleRepository.Update(article);
            await _unitOfWork.Commit();
            return article;
        }

        [HttpDelete]
        public async Task RemoveArticle(Guid Id)
        {
            await _articleRepository.RemoveAsync(Id);
            await _unitOfWork.Commit();
        }
    }
}
