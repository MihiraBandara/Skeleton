using MediatR;

namespace Skeleton.Domain.Primitives
{
    public interface IDomaineventHandler<TNotification>
        : INotificationHandler<TNotification>
        where TNotification : INotification
    {
        Task Handle(TNotification notification);
    }
}
