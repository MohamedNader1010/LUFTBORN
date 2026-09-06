using MediatR;
using Microsoft.Extensions.Logging;

namespace LUFTBORN.Application.Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling request: {@Request}", request);

        var response = await next();

        logger.LogInformation("Handled response: {@Response}", response);

        return response;
    }
}
