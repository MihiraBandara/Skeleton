using Skeleton.Domain.Primitives;
using Skeleton.Domain.ValueObjects;

namespace Skeleton.Domain.Entities
{
    public class Order(OrderId id) : AggregateRoot<OrderId>(id)
    {
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();

        public IReadOnlyList<OrderItem> OrderItems => _orderItems;

        public Price TotalAmount { get; private set; }

        public void AddOrderItem(Product product, Quantity quantity, OrderId orderId)
        {
            var orderItem = OrderItem.Create(new OrderItemId(new Guid()), product, orderId, quantity);
            _orderItems.Add(orderItem);
            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (var orderItem in _orderItems)
            {
                totalAmount += orderItem.Subtotal.Amount;
            }

            TotalAmount = Price.Create(totalAmount, _orderItems.FirstOrDefault()?.Subtotal.Currency ?? "");
        }
    }

    public record OrderId(Guid Value);
}
