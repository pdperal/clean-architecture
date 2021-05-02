using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0,
                "Invalid object state. Id is invalid.");

            ValidateDomain(name, description, price, stock, image);

            Id = id;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid object state. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid object state. Name requires at least 3 characteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid object state. Name is required.");
            
            DomainExceptionValidation.When(description.Length < 5,
                "Invalid object state. Description requires at least 5 characteres.");

            DomainExceptionValidation.When(price < 0,
                "Invalid object state. Price value is negative.");
            
            DomainExceptionValidation.When(stock < 0,
                "Invalid object state. Stock quantity is negative.");

            DomainExceptionValidation.When(image?.Length > 250,
                "Invalid object state. Image name has more then 250 characteres.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
    }
}
