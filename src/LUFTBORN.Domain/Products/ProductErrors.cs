using ErrorOr;
namespace LUFTBORN.Domain.Products;

public static class ProductErrors
{
    public static Error NotFound { get; } =
        Error.NotFound(
            code: "Product.NotFound",
            description: "Product not found");

    public static Error InvalidPrice { get; } =
        Error.Validation(
            code: "Product.InvalidPrice",
            description: "Product price cannot be negative");
}