using ErrorOr;

using LUFTBORN.Application.Common.Interfaces;
using LUFTBORN.Domain.Products;

using MediatR;

namespace LUFTBORN.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(
    IProductsRepository productsRepository)
    : IRequestHandler<CreateProductCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = new Product(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.Price,
            request.CategoryId,
            request.CreateByUserId);

        await productsRepository.AddAsync(
            product,
            cancellationToken);

        return product.Id;
    }
}