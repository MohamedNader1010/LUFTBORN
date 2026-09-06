using ErrorOr;

using LUFTBORN.Application.Common.Interfaces;
using LUFTBORN.Contracts.Users;

using MediatR;

namespace LUFTBORN.Application.Users.Queries.GetUsers;

public class GetUsersQueryHandler(
    IUsersRepository usersRepository)
    : IRequestHandler<GetUsersQuery, ErrorOr<List<UserResponse>>>
{
    public async Task<ErrorOr<List<UserResponse>>> Handle(
        GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await usersRepository.GetAllAsync(
            cancellationToken);

        return users
            .Select(user => new UserResponse(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email))
            .ToList();
    }
}