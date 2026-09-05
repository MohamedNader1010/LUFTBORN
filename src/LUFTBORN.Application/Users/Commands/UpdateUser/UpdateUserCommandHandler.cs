using ErrorOr;
using LUFTBORN.Application.Common.Interfaces;
using MediatR;

namespace LUFTBORN.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(
    IUsersRepository usersRepository)
    : IRequestHandler<UpdateUserCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(
        UpdateUserCommand request,
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

        user.Update(
            request.FirstName,
            request.LastName,
            request.Email);

        await usersRepository.UpdateAsync(user, cancellationToken);

        return Result.Success;
    }
}