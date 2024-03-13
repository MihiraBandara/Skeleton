namespace Skeleton.Domain.Primitives
{
    public abstract class AggregateRoot<TId> : BaseDomainEntity<TId>, IHasDomainEvents
    {
        private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();

        ICollection<DomainEvent> IHasDomainEvents.DomainEvents => _domainEvents;

        public AggregateRoot(TId id) : base(id){ }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public void RemoveDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
