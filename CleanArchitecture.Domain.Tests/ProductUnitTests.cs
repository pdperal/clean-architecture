using System;
using Xunit;
using FluentAssertions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Tests
{
    public class ProductUnitTests
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, "product image");

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product description", 9.99m, 99, "product image");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid object state. Id is invalid.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            // Arrange
            Action action = () => new Product(1, "Pr", "Product description", 9.99m, 99, "product image");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid object state. Name requires at least 3 characteres.");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, "product imageeeeee" +
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee" +
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee" +
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee" +
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee" +
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee" +
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid object state. Image name has more then 250 characteres.");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, null);

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithEmptymageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, "");

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, value, "product image");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid object state. Stock quantity is negative.");
        }
    }
}
