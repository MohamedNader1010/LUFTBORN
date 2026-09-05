using ErrorOr;
using LUFTBORN.Domain.Categories;
using LUFTBORN.Domain.Common;
using LUFTBORN.Domain.Products.Events;
using LUFTBORN.Domain.Users;

namespace LUFTBORN.Domain.Products;

public class Product : Entity
{
    public string Name { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public decimal Price { get; private set; }

    public Guid CategoryId { get; private set; }

    public Category Category { get; private set; } = null!;

    public Product(
        Guid id,
        string name,
        string description,
        decimal price,
        Guid categoryId,
        Guid createdByUserId)
        : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;

        _domainEvents.Add(new ProductCreatedEvent(this));
    }

    public ErrorOr<Success> Update(
        string name,
        string description,
        decimal price,
        Guid categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Error.Validation(
                code: "Product.InvalidName",
                description: "Product name cannot be empty.");
        }

        if (price < 0)
        {
            return Error.Validation(
                code: "Product.InvalidPrice",
                description: "Product price cannot be negative.");
        }

        if (categoryId == Guid.Empty)
        {
            return Error.Validation(
                code: "Product.InvalidCategory",
                description: "Category is required.");
        }

        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;

        return Result.Success;
    }

    private Product()
    {
    }
}