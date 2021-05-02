using System;
using Xunit;
using FluentAssertions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            // Arrange
            Action action = () => new Category(1, "Category Name");

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            // Arrange
            Action action = () => new Category(-1, "Category Name");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid object state. Id is required.");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            // Arrange
            Action action = () => new Category(1, "Cat");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid object state. Name requires at least 3 characteres.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            // Arrange
            Action action = () => new Category(1, "");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid object state. Name is required.");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            // Arrange
            Action action = () => new Category(1, null);

            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
