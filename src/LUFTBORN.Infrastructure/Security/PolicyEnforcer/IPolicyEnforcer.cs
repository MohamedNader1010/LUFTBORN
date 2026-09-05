using ErrorOr;
using LUFTBORN.Application.Common.Security.Request;
using LUFTBORN.Infrastructure.Security.CurrentUserProvider;

namespace LUFTBORN.Infrastructure.Security.PolicyEnforcer;

public interface IPolicyEnforcer
{
    public ErrorOr<Success> Authorize<T>(
        IAuthorizeableRequest<T> request,
        CurrentUser currentUser,
        string policy);
}