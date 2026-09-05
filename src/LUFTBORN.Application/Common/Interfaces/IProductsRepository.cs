using LUFTBORN.Domain.Products;

namespace LUFTBORN.Application.Common.Interfaces;

public interface IProductsRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken);
    Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken);
    Task RemoveAsync(Product product, CancellationToken cancellationToken);
    Task UpdateAsync(Product product, CancellationToken cancellationToken);
}