using ErrorOr;

using LUFTBORN.Application.Common.Interfaces;

using MediatR;

namespace LUFTBORN.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(
    IUsersRepository usersRepository)
    : IRequestHandler<DeleteUserCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(
        DeleteUserCommand request,
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

        await usersRepository.RemoveAsync(user, cancellationToken);

        return Result.Success;
    }
}