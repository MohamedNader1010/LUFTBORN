using ErrorOr;

using LUFTBORN.Application.Common.Security.Permissions;
using LUFTBORN.Application.Common.Security.Policies;
using LUFTBORN.Application.Common.Security.Request;

namespace LUFTBORN.Application.Users.Commands.UpdateUser;

[Authorize(
    Permissions = Permission.User.Update)]
public record UpdateUserCommand(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email)
    : IAuthorizeableRequest<ErrorOr<Success>>;