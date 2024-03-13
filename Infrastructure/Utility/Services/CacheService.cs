using Microsoft.Extensions.Caching.Memory;
using Skeleton.Application.Abstractions.Utility;

namespace Skeleton.Utility.Services
{
    public sealed class CacheService : ICacheService
    {
        private static readonly TimeSpan DefaultExpirationTime = TimeSpan.FromMinutes(5);
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task<T> GetOrCreateAsync<T>(string key, Func<CancellationToken, Task<T>> factory, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
        {
            T result = await _memoryCache.GetOrCreateAsync(
                key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(expiration ?? DefaultExpirationTime);
                    return factory(cancellationToken);
                });

            return result;
        }
    }
}
