using ErrorOr;

using LUFTBORN.Application.Common.Security.Permissions;
using LUFTBORN.Application.Common.Security.Policies;
using LUFTBORN.Application.Common.Security.Request;

namespace LUFTBORN.Application.Products.Commands.CreateProduct;

[Authorize(
    Permissions = Permission.Product.Create,
    Policies = Policy.SelfOrAdmin)]
public record CreateProductCommand(
    Guid UserId,
    string Name,
    string Description,
    decimal Price, Guid CategoryId, Guid CreateByUserId)
    : IAuthorizeableRequest<ErrorOr<Guid>>;