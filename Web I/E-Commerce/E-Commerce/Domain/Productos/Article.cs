namespace E_Commerce.Domain.Productos
{
    public class Article
    {
        public Guid Id { get; set; }
        public List<Category> Categories { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Article(Guid id, List<Category> categories, Brand brand, string name, string description, double price)
        {
            Id = id;
            Categories = categories;
            Brand = brand;
            Name = name;
            Description = description;
            Price = price;
        }

        public Article(List<Category> categories, Brand brand, string name, string description, double price)
        : this(Guid.Empty, categories, brand, name, description, price)
        { }

        public Article() : this(Guid.Empty, new List<Category>(), new Brand(), "", "", 0) { }


        public void addCategory(Category category)
        {
            Categories.Add(category);
        }

        public void removeCategory(Category category)
        {
            Categories.Remove(category);
        }

        public void updateCategory(Category category)
        {
            Categories[Categories.IndexOf(category)] = category;
        }
    }
}
