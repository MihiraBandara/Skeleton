using Skeleton.Application.Abstractions.Messaging;

namespace Skeleton.Application.Features.Products.Commands
{
    public class CreateProductCommand : ICommand
    {
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Currency { get; set; } = string.Empty;
    }
}
