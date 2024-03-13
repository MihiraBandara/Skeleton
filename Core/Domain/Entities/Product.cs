using Skeleton.Domain.DomainEvents;
using Skeleton.Domain.Primitives;
using Skeleton.Domain.ValueObjects;

namespace Skeleton.Domain.Entities
{
    public class Product : AggregateRoot<ProductId>
    {
        public Product(ProductId id) : base(id) { }
        public Product() : base(new ProductId(new Guid())) { }
        private Product(ProductId id, string name, Price price) : base(id)
        {
            Name = name;
            Price = price;

        }
        public string Name { get; private set; } = string.Empty;
        public Price Price { get; private set; }
        public static Product Create(ProductId id, string name, Price price)
        {
            var product = new Product(id, name, price);
            product.AddDomainEvent(new ProductCreatedDomainEvent(Guid.NewGuid(), id));
            return product;
        }
    }

    public record ProductId(Guid Value);
}
