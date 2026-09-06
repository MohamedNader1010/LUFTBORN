using ErrorOr;

using LUFTBORN.Application.Common.Security.Permissions;
using LUFTBORN.Application.Common.Security.Policies;
using LUFTBORN.Application.Common.Security.Request;

namespace LUFTBORN.Application.Users.Commands.DeleteUser;

[Authorize(
    Permissions = Permission.User.Delete)]
public record DeleteUserCommand(
    Guid UserId)
    : IAuthorizeableRequest<ErrorOr<Success>>;