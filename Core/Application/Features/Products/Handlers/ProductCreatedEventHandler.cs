using MediatR;
using Skeleton.Application.Abstractions.Messaging;
using Skeleton.Application.Features.Products.Events;
using Skeleton.Domain.DomainEvents;

namespace Skeleton.Application.Features.Products.Handlers
{
    internal sealed class ProductCreatedEventHandler
        : IDomainEventHandler<ProductCreatedDomainEvent>
    {
        private readonly IMediator _mediator;

        public ProductCreatedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new ProductCreatedIntergrationEvent(notification.productId.Value));
        }
    }
}
