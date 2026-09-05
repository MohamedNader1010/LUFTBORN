using ErrorOr;

using LUFTBORN.Application.Common.Security.Permissions;
using LUFTBORN.Application.Common.Security.Policies;
using LUFTBORN.Application.Common.Security.Request;

namespace LUFTBORN.Application.Users.Commands.CreateUser;

[Authorize(
    Permissions = Permission.User.Create)]
public record CreateUserCommand(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email)
    : IAuthorizeableRequest<ErrorOr<Guid>>;