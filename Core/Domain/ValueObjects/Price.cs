using Skeleton.Domain.Entities;
using Skeleton.Domain.Primitives;

namespace Skeleton.Domain.ValueObjects
{
    public class Price : ValueObject<Price>
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Price(){}

        private Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency.ToUpper();
        }

        public override bool Equals(Price other)
        {
            return Amount == other.Amount && Currency == other.Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

        public override string ToString()
        {
            return $"{Amount:F2} {Currency}";
        }

        public static Price Create(decimal amount, string currency)
        {
            var price = new Price(amount, currency);
            return price;
        }
    }
}
