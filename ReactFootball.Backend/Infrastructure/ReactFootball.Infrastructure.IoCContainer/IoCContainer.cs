using Microsoft.Extensions.DependencyInjection;

using ReactFootball.Infrastructure.IoCContainer.Contracts;
using ReactFootball.Infrastructure.IoCContainer.IoCPackages;

namespace ReactFootball.Infrastructure.IoCContainer
{
    public static class IoCContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            IPackage[] packages = new IPackage[]
            {
                new CachePackage(),
                new DataProvidersPackage()
            };

            foreach (var package in packages)
            {
                package.RegisterServices(services);
            }
        }
    }
}
