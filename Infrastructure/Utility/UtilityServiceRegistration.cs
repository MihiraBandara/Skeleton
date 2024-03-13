using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Skeleton.Application.Abstractions.Utility;
using Skeleton.Utility.Services;

namespace Skeleton.Utility
{
    public static class UtilityServiceRegistration
    {
        public static IServiceCollection ConfigureUtilityService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, loggerConfig) =>
                loggerConfig.ReadFrom.Configuration(context.Configuration));
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, CacheService>();
            return services;
        }
    }
}
