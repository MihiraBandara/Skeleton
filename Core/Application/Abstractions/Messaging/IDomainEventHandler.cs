using MediatR;

namespace Skeleton.Application.Abstractions.Messaging
{
    public interface IDomainEventHandler<TNotification>
        : INotificationHandler<TNotification>
        where TNotification : INotification
    {
        Task Handle(TNotification notification, CancellationToken cancellationToken);
    }
}
