namespace E_Commerce.Domain.Productos
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Category()
        {
            Id = Guid.Empty;
            Name = "";
        }
    }

}
