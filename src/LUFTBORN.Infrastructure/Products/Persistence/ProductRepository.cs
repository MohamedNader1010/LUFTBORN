using LUFTBORN.Application.Common.Interfaces;
using LUFTBORN.Domain.Products;
using LUFTBORN.Infrastructure.Common.Persistence;

using Microsoft.EntityFrameworkCore;

namespace LUFTBORN.Infrastructure.Products.Persistence;

public class ProductRepository(AppDbContext _dbContext) : IProductsRepository
{
    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _dbContext.Products.AddAsync(product, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == userId, cancellationToken);
    }

    public async Task RemoveAsync(Product product, CancellationToken cancellationToken)
    {
        _dbContext.Remove(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        _dbContext.Update(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}