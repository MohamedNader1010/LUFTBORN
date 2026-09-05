using System.Security.Claims;

using Microsoft.AspNetCore.Http;

namespace LUFTBORN.Infrastructure.Security.CurrentUserProvider;

public class CurrentUserProvider : ICurrentUserProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public CurrentUser GetCurrentUser()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user is null || user.Identity?.IsAuthenticated != true)
        {
            throw new UnauthorizedAccessException("User is not authenticated");
        }

        var userIdValue = GetClaimValue(user, "sub", ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdValue, out var userId))
        {
            throw new UnauthorizedAccessException("Token is missing a valid user identifier (sub) claim");
        }

        var firstName = GetClaimValue(user, "given_name", ClaimTypes.GivenName);
        var lastName = GetClaimValue(user, "family_name", ClaimTypes.Surname);
        var email = GetClaimValue(user, "email", ClaimTypes.Email);

        var roles = GetClaimValues(user, ClaimTypes.Role);
        var permissions = GetClaimValues(user, "permissions");

        return new CurrentUser(
            userId,
            firstName ?? string.Empty,
            lastName ?? string.Empty,
            email ?? string.Empty,
            permissions,
            roles
        );
    }

    private static string? GetClaimValue(ClaimsPrincipal user, params string[] claimTypes)
    {
        foreach (var claimType in claimTypes)
        {
            var value = user.FindFirst(claimType)?.Value;
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
        }

        return null;
    }

    private static IReadOnlyList<string> GetClaimValues(ClaimsPrincipal user, string claimType)
    {
        return user.FindAll(claimType)
            .Select(c => c.Value)
            .Where(v => !string.IsNullOrEmpty(v))
            .ToList();
    }
}