using Skeleton.Domain.Primitives;

namespace Skeleton.Domain.ReadModels
{
    public class OrderItemReadModel : BaseDomainEntity
    {
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public required OrderReadModel Order { get; set; }
        public required ProductReadModel Item { get; set; }
    }
}
