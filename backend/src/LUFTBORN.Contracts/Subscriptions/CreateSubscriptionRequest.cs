using LUFTBORN.Contracts.Common;

namespace LUFTBORN.Contracts.Subscriptions;

public record CreateSubscriptionRequest(
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType);