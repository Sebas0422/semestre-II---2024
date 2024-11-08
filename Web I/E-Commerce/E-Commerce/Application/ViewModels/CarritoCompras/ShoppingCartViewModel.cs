using E_Commerce.Application.ViewModels.Usuarios;

namespace E_Commerce.Application.ViewModels.CarritoCompras
{
    public class ShoppingCartViewModel
    {
        public Guid Int { get; set; }
        public UserViewModel User { get; set; }
        public DateTime DateCreated { get; set; }
        public List<OrderVIewModel> Orders { get; set; }
    }
}
