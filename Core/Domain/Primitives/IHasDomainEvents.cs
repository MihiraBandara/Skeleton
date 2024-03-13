namespace Skeleton.Domain.Primitives
{
    public interface IHasDomainEvents
    {
        ICollection<DomainEvent> DomainEvents { get; }
        void AddDomainEvent(DomainEvent domainEvent);
        void RemoveDomainEvent(DomainEvent domainEvent);
        void ClearDomainEvents();
    }
}
