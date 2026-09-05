using LUFTBORN.Domain.Common;

namespace LUFTBORN.Domain.Products.Events;

public record ProductCreatedEvent(Product Product) : IDomainEvent;