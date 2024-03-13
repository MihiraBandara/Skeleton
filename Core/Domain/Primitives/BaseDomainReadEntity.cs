namespace Skeleton.Domain.Primitives
{
    public abstract class BaseDomainReadEntity<TId> : BaseEntity
    {
        public TId Id { get; private init; }
    }
}
