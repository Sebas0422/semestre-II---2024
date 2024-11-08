using E_Commerce.Domain.Repository.Usuarios;
using E_Commerce.Domain.UnitOfWorkPattern;
using E_Commerce.Domain.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers.Usuarios
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.FindAllAsync();
        }

        [HttpGet]
        public async Task<User> GetUserById(Guid Id)
        {
            return await _userRepository.FindByIdAsync(Id);
        }

        [HttpPost]
        public async Task<User> CreateUser([FromBody] User user)
        {
            user = await _userRepository.CreateAsync(user);
            await _unitOfWork.Commit();
            return user;
        }

        [HttpPut]
        public async Task<User> UpdateUser([FromBody] User user)
        {
            user = _userRepository.Update(user);
            await _unitOfWork.Commit();
            return user;
        }

        [HttpDelete]
        public async Task RemoveUser(Guid Id)
        {
            await _userRepository.RemoveAsync(Id);
            await _unitOfWork.Commit();
        }
    }
}   
