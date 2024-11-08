using E_Commerce.Domain.CarritoCompras;
using E_Commerce.Domain.Productos;
using E_Commerce.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Ordes { get; set; }
    }
}
