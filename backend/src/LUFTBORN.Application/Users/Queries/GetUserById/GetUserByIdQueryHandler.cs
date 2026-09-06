using ErrorOr;
using LUFTBORN.Application.Common.Interfaces;
using LUFTBORN.Contracts.Users;
using MediatR;

namespace LUFTBORN.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler(
    IUsersRepository usersRepository)
    : IRequestHandler<GetUserByIdQuery, ErrorOr<UserResponse>>
{
    public async Task<ErrorOr<UserResponse>> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetByIdAsync(
            request.UserId,
            cancellationToken);

        if (user is null)
        {
            return Error.NotFound(
                code: "User.NotFound",
                description: "User was not found.");
        }

        return new UserResponse(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email);
    }
}