namespace E_Commerce.Application.ViewModels.Productos
{
    public class ArticleViewModel
    {
        public Guid Id { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public BrandViewModel Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public ArticleViewModel(Guid id,
            List<CategoryViewModel> categories,
            BrandViewModel brand,
            string name,
            string description,
            double price)
        {
            Id = id;
            Categories = categories;
            Brand = brand;
            Name = name;
            Description = description;
            Price = price;
        }

        public ArticleViewModel(List<CategoryViewModel> categories,
            BrandViewModel brand,
            string name,
            string description,
            double price)
        : this(Guid.Empty, categories, brand, name, description, price) { }

        public ArticleViewModel() : this(Guid.Empty, new List<CategoryViewModel>(), new BrandViewModel(), "", "", 0) { }
    }
}
