using ErrorOr;
using LUFTBORN.Domain.Common;
using LUFTBORN.Domain.Products;

namespace LUFTBORN.Domain.Categories;

public class Category : Entity
{
    private readonly List<Product> _products = [];

    public string Name { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    public Category(
        Guid id,
        string name,
        string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    public ErrorOr<Success> Update(
        string name,
        string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Error.Validation(
                code: "Category.InvalidName",
                description: "Category name cannot be empty.");
        }

        Name = name;
        Description = description;

        return Result.Success;
    }

    private Category()
    {
    }
}