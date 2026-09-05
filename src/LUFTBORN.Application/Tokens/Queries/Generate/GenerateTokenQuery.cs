using ErrorOr;

using LUFTBORN.Application.Authentication.Queries.Login;
using LUFTBORN.Domain.Users;

using MediatR;

namespace LUFTBORN.Application.Tokens.Queries.Generate;

public record GenerateTokenQuery(
    Guid? Id,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType,
    List<string> Permissions,
    List<string> Roles) : IRequest<ErrorOr<GenerateTokenResult>>;