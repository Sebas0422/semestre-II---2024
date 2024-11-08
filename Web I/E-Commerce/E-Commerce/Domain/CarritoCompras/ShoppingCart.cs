using E_Commerce.Domain.CarritoCompras;
using E_Commerce.Domain.Usuarios;

namespace E_Commerce.Domain.CarritoCompras
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Order> Orders { get; set; }

        public ShoppingCart(Guid id, User user, DateTime dateCreated)
        {
            Id = id;
            User = user;
            DateCreated = dateCreated;
            Orders = new List<Order>();
        }

        public ShoppingCart(Guid userId, DateTime dateCreated)
        : this(Guid.Empty, new User(), dateCreated)
        { }

        public ShoppingCart() { }
    }
}
