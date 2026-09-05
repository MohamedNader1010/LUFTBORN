using ErrorOr;

namespace LUFTBORN.Domain.Users;

public static class UserErrors
{
    public static Error UserNotFound { get; } = Error.Validation(
        code: "UserErrors.UserNotFound",
        description: "User in not found");
    public static Error DuplicateUser { get; } = Error.Validation(
        code: "UserErrors.DuplicateUser",
        description: "User is already exists");
}