using ErrorOr;

using LUFTBORN.Application.Common.Security.Permissions;
using LUFTBORN.Application.Common.Security.Request;
using LUFTBORN.Contracts.Users;

using MediatR;

namespace LUFTBORN.Application.Users.Queries.GetUserById;

[Authorize(
    Permissions = Permission.User.Get)]
public record GetUserByIdQuery(Guid UserId) :
    IAuthorizeableRequest<ErrorOr<UserResponse>>;