using LUFTBORN.Domain.Common;

namespace LUFTBORN.Domain.Users.Events;

public record UserCreatedEvent(User user) : IDomainEvent;