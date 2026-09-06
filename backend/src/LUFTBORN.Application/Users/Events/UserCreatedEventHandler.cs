using LUFTBORN.Application.Common.Interfaces;
using LUFTBORN.Domain.Users.Events;

using MediatR;

namespace LUFTBORN.Application.Users.Events;

public class UserCreatedEventHandler(
    IEmailService emailService) : INotificationHandler<UserCreatedEvent>
{
    public async Task Handle(UserCreatedEvent ev, CancellationToken cancellationToken)
    {
        var user = ev.user;


        var emailBody = $"""
                         Hello,

                         user is created successfully.

                         firstname: {user.FirstName}
                         email:  {user.Email}

                         Thank you.
                         """;

        await emailService.SendAsync(
            user.Email,
            "User Created Successfully",
            emailBody,
            cancellationToken);
    }
}