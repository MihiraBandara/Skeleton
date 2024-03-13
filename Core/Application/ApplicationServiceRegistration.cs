using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Skeleton.Application.Behaviours;
using Skeleton.Application.Features.Products.Commands;
using Skeleton.Application.Features.Products.Validators;
using System.Reflection;

namespace Skeleton.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(CachingBehaviour<,>));
              });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            return services;
        }
    }
}
