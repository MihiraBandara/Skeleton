using Skeleton.Application.Abstractions.Messaging;
using Skeleton.Application.Dtos.Products;

namespace Skeleton.Application.Features.Products.Queries
{
    public record GetAllProductsQuery : ICachedQuery<List<GetProductDto>>
    {
        public string Key => $"get-all-products";

        public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
    }
}
