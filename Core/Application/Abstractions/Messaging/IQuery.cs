using MediatR;
using Skeleton.Application.Shared;

namespace Skeleton.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
