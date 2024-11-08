using E_Commerce.Domain.CarritoCompras;
using E_Commerce.Domain.Repository.CarritoCompras;
using E_Commerce.Domain.UnitOfWorkPattern;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers.CarritoCompras
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepository.FindAllAsync();
        }

        [HttpGet]
        public async Task<Order> GetOrderById(Guid Id)
        {
            return await _orderRepository.FindByIdAsync(Id);
        }

        [HttpPost]
        public async Task<Order> CreateOrder([FromBody] Order order)
        {
            order = await _orderRepository.CreateAsync(order);
            await _unitOfWork.Commit();
            return order;
        }

        [HttpPut]
        public async Task<Order> UpdateOrder([FromBody] Order order)
        {
            order = _orderRepository.Update(order);
            await _unitOfWork.Commit();
            return order;
        }

        [HttpDelete]
        public async Task RemoveOrder(Guid Id)
        {
            await _orderRepository.RemoveAsync(Id);
            await _unitOfWork.Commit();
        }

    }
}
