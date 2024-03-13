using MediatR;
using Skeleton.Application.Abstractions.Messaging;
using Skeleton.Application.Abstractions.Utility;

namespace Skeleton.Application.Behaviours
{
    public class CachingBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICachedQuery
    {
        private readonly ICacheService _cacheService;

        public CachingBehaviour(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            return await _cacheService.GetOrCreateAsync(
                request.Key,
                _ => next(),
                request.Expiration,
               cancellationToken);
        }
    }
}
