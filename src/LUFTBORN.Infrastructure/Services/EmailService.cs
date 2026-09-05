using FluentEmail.Core;

using LUFTBORN.Application.Common.Interfaces;

namespace LUFTBORN.Infrastructure.Services;

public class EmailService(IFluentEmail fluentEmail) : IEmailService
{
    public async Task SendAsync(
        string to,
        string subject,
        string body,
        CancellationToken cancellationToken = default)
    {
        await fluentEmail
            .To(to)
            .Subject(subject)
            .Body(body)
            .SendAsync(cancellationToken);
    }
}