using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skeleton.Application.Abstractions.Persistance;
using Skeleton.Persistance.Repositories;
using System.Data;
using Skeleton.Persistance.Extensions;
using Npgsql;

namespace Skeleton.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<SkeletonWriteDbContext>(options =>
                {
                    options.UseNpgsql(
                        configuration.GetConnectionString("SkeletonConnectionString"),
                        b =>
                        {
                            b.MigrationsAssembly(typeof(SkeletonWriteDbContext).Assembly.FullName);
                            b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                        })
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll); ;
                });

            services.AddScoped<IDbConnection>((sp) =>
            {
                return new NpgsqlConnection(configuration.GetConnectionString("SkeletonConnectionString"));
            });

            services.AddScoped(typeof(IGenericWriteRepository<>), typeof(GenericWriteRepository<>));
            services.AddScoped(typeof(IGenericReadRepository<>), typeof(GenericReadRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }
    }
}
