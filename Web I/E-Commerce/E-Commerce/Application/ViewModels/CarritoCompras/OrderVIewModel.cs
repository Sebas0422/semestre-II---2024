using E_Commerce.Application.ViewModels.Productos;

namespace E_Commerce.Application.ViewModels.CarritoCompras
{
    public class OrderVIewModel
    {
        public ShoppingCartViewModel ShoppingCart { get; set; }
        public ArticleViewModel Article { get; set; }
        public double Quantity { get; set; }
    }
}
