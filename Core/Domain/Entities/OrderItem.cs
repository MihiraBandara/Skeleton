using Skeleton.Domain.Primitives;
using Skeleton.Domain.ValueObjects;

namespace Skeleton.Domain.Entities
{
    public class OrderItem : BaseDomainEntity<OrderItemId>
    {
        public OrderItem(OrderItemId id): base(id) { }
        private OrderItem(OrderItemId id, ProductId productId, OrderId orderId, Quantity quantity) : base(id)
        {
            OrderId = orderId;
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;

        }

        public Product Product { get; private set; }
        public Quantity Quantity { get; private set; }
        public OrderId OrderId { get; private set; }
        public ProductId ProductId { get; private set; }
        public Price Subtotal { get; private set; }

        public static OrderItem Create(OrderItemId id, Product product, OrderId orderId, Quantity quantity)
        {
            var orderItem = new OrderItem(id,product.Id, orderId, quantity);
            return orderItem;
        }
    }

    public record OrderItemId(Guid Value);
}
