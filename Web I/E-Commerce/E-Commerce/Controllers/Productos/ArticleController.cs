using E_Commerce.Domain.Productos;
using E_Commerce.Domain.Repository.Productos;
using E_Commerce.Domain.UnitOfWorkPattern;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers.Productos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleController(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }

        //api/article/GetArticles
        [Route("GetArticles")]
        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            List<Article> articles = await _articleRepository.FindAllAsync();
            return Ok(articles);
        }

        [HttpGet]
        [Route("GetArticleById/{Id}")]
        public async Task<Article> GetArticleById([FromRoute] Guid Id)
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
        [Route("RemoveArticle/{articleId}")]
        public async Task RemoveArticle([FromRoute] Guid Id)
        {
            await _articleRepository.RemoveAsync(Id);
            await _unitOfWork.Commit();
        }
    }
}
