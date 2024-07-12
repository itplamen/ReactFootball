using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ReactFootball.Infrastructure.IoCContainer.Contracts;
using ReactFootball.Infrastructure.IoCContainer.IoCPackages;

namespace ReactFootball.Infrastructure.IoCContainer
{
    public static class IoCContainer
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            IPackage[] packages = new IPackage[]
            {
                new CachePackage(configuration),
                new DataProvidersPackage()
            };

            foreach (var package in packages)
            {
                package.RegisterServices(services);
            }
        }
    }
}
