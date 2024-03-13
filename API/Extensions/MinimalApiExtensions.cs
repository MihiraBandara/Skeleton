using Skeleton.Api.Interfaces;

namespace Skeleton.Api.Extensions
{
    public static class MinimalApiExtensions
    {
        public static void MapEndpoint(this WebApplication app)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var classes = assemblies.Distinct().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IApiModule).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var classe in classes)
            {
                var instance = Activator.CreateInstance(classe) as IApiModule;
                instance?.MapEndpoint(app);
            }
        }
    }
}
