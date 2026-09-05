using ErrorOr;

using LUFTBORN.Application.Common.Interfaces;
using LUFTBORN.Domain.Users;

using MediatR;

namespace LUFTBORN.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(
    IUsersRepository usersRepository)
    : IRequestHandler<CreateUserCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = new User(
            Guid.NewGuid(),
            request.FirstName,
            request.LastName,
            request.Email);

        await usersRepository.AddAsync(
            user,
            cancellationToken);

        return user.Id;
    }
}