using LUFTBORN.Contracts.Common;

namespace LUFTBORN.Contracts.Subscriptions;

public record SubscriptionResponse(
    Guid Id,
    Guid UserId,
    SubscriptionType SubscriptionType);