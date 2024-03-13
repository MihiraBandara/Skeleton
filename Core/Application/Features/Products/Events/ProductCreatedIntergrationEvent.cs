using Skeleton.Domain.Primitives;

namespace Skeleton.Application.Features.Products.Events
{
    internal record ProductCreatedIntergrationEvent(Guid id) : IIntergrationEvent
    {
    }
}
