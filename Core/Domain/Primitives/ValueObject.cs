namespace Skeleton.Domain.Primitives
{
    public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        public abstract bool Equals(T other);

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            return Equals((T)obj);
        }

        public abstract override int GetHashCode();

        public static bool operator == (ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
