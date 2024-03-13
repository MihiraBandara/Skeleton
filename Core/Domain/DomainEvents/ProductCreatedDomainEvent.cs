using Skeleton.Domain.Entities;
using Skeleton.Domain.Primitives;

namespace Skeleton.Domain.DomainEvents
{
    public record ProductCreatedDomainEvent(Guid id, ProductId productId) : DomainEvent(id);
}
