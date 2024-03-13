namespace Skeleton.Domain.Primitives
{
    public abstract class BaseDomainEntity<TId> : BaseDomainAuditableEntity, IEquatable<TId>
    {
        public TId Id { get; private init; }

        protected BaseDomainEntity(TId id)
        {
            if (id == null || id.Equals(default(TId)))
            {
                throw new ArgumentException("Id must be specified", nameof(id));
            }

            Id = id;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BaseDomainEntity<TId> other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(TId? other)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(BaseDomainEntity<TId> a, BaseDomainEntity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(BaseDomainEntity<TId> a, BaseDomainEntity<TId> b)
        {
            return !(a == b);
        }
    }

    public abstract class BaseDomainEntity : BaseEntity;
}
