using CleanArchitecture.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, 
                "Invalid object state. Id is required.");
            ValidateDomain(name);

            Id = id;
        }
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid object state. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid object state. Name requires at least 3 characteres.");

            Name = name;
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }
    }
}
