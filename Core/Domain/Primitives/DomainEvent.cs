namespace Skeleton.Domain.Primitives
{
    public record DomainEvent(Guid Id) : IDomainEvent
    {
    }
}
