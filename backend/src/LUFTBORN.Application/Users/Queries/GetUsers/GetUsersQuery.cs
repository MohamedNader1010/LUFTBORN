using ErrorOr;

using LUFTBORN.Contracts.Users;

using MediatR;

namespace LUFTBORN.Application.Users.Queries.GetUsers;

public record GetUsersQuery
    : IRequest<ErrorOr<List<UserResponse>>>;