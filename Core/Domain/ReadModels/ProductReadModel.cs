using Skeleton.Domain.Primitives;

namespace Skeleton.Domain.ReadModels
{
    public class ProductReadModel : BaseDomainReadEntity<Guid>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public string Currency { get; private set; }
    }
}
