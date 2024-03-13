namespace Skeleton.Application.Dtos.Products
{
    public class GetProductDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public string Currency { get; private set; }
    }
}
