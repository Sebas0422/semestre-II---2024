using E_Commerce.Domain.CarritoCompras;
using E_Commerce.Domain.Repository.CarritoCompras;
using E_Commerce.Domain.UnitOfWorkPattern;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers.CarritoCompras
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IUnitOfWork unitOfWork)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<ShoppingCart>> GetShoppingCarts()
        {
            return await _shoppingCartRepository.FindAllAsync();
        }

        [HttpGet]
        public async Task<ShoppingCart> GetShoppingCartById(Guid Id)
        {
            return await _shoppingCartRepository.FindByIdAsync(Id);
        }

        [HttpPost]
        public async Task<ShoppingCart> CreateShoppingCart([FromBody] ShoppingCart shoppingCart)
        {
            shoppingCart = await _shoppingCartRepository.CreateAsync(shoppingCart);
            await _unitOfWork.Commit();
            return shoppingCart;
        }

        [HttpPut]
        public async Task<ShoppingCart> UpdateShoppingCart([FromBody] ShoppingCart shoppingCart)
        {
            shoppingCart = _shoppingCartRepository.Update(shoppingCart);
            await _unitOfWork.Commit();
            return shoppingCart;
        }

        [HttpDelete]
        public async Task RemoveShoppingCart(Guid Id)
        {
            await _shoppingCartRepository.RemoveAsync(Id);
            await _unitOfWork.Commit();
        }
    }
}
