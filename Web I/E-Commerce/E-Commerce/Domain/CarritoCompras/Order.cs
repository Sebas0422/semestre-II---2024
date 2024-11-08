using E_Commerce.Domain.Productos;

namespace E_Commerce.Domain.CarritoCompras
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Guid ArticlesId { get; set; }
        public int Quantity { get; set; }

        public Order(Guid shoppingCart, Guid articles, int quantity)
        {
            ShoppingCartId = shoppingCart;
            ArticlesId = articles;
            Quantity = quantity;
        }

        public Order(Guid shoppingCart)
        : this(shoppingCart, Guid.Empty, 0)
        { }

        public Order()
        {

        }
        /*
        public void addArticle(Article article)
        {
            Articles.Add(article);
        }

        public void removeArticle(Article article)
        {
            Articles.Remove(article);
        }

        public void updateArticle(Article article)
        {
            Articles[Articles.IndexOf(article)] = article;
        }*/
    }
}
