using Skeleton.Domain.Primitives;

namespace Skeleton.Domain.ValueObjects
{
    public class Quantity : ValueObject<Quantity>
    {
        public int Amount { get; }
        public string Measurement { get; }

        public Quantity() { }
        private Quantity(int amount, string measurement)
        {
            if (string.IsNullOrWhiteSpace(measurement))
                throw new ArgumentException("Currency must not be null or empty", nameof(measurement));

            Amount = amount;
            Measurement = measurement.ToUpper();
        }

        public override bool Equals(Quantity other)
        {
            return Amount == other.Amount && Measurement == other.Measurement;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Measurement);
        }

        public override string ToString()
        {
            return $"{Amount:F2} {Measurement}";
        }

        public static Quantity Create(int amount, string measurement)
        {
            var quantity = new Quantity(amount, measurement);
            return quantity;
        }
    }
}
