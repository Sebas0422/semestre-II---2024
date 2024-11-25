using E_Commerce.Domain.Productos;

namespace E_Commerce.Domain.CarritoCompras
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ArticlesId { get; set; }
        public Article Article { get; set; }
        public int Quantity { get; set; }

        public Order(Guid articles, int quantity)
        {
            ArticlesId = articles;
            Quantity = quantity;
        }

        public Order(Guid shoppingCart)
        : this(Guid.Empty, 0)
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
