using Skeleton.Domain.Primitives;
using System.Security.Cryptography;

namespace Skeleton.Domain.ReadModels
{
    public class OrderReadModel : AggregateRootRead<Guid>
    {
        public string CustomerName { get; set; } = string.Empty;
        public List<OrderItemReadModel> OrderItems { get; set; } = new List<OrderItemReadModel>();
    }
}
