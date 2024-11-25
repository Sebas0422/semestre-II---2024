using E_Commerce.Domain.Imagen;
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Productos
{
    public class Article
    {
        public Guid Id { get; set; }
        public Category Categories { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [JsonIgnore]
        public Image Imagen { get; set; }
        public int? ImagenId { get; set; }
        public Article()
        {
            Id = Guid.NewGuid();
            Categories = new Category();
            Brand = new Brand();
            Name = String.Empty; ;
            Description = String.Empty;
            Price = 0;
        }
    }
}
