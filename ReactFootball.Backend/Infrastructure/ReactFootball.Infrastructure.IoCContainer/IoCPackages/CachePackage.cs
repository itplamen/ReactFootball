using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ReactFootball.Infrastructure.IoCContainer.Contracts;
using ReactFootball.Services.Cache;
using ReactFootball.Services.Cache.Contracts;
using ReactFootball.Services.Models.ScoreBat;

namespace ReactFootball.Infrastructure.IoCContainer.IoCPackages
{
    public sealed class CachePackage : IPackage
    {
        private int absoluteExpiration;
        private readonly IConfiguration configuration;

        public CachePackage(IConfiguration configuration)
        {
            this.configuration = configuration;
            absoluteExpiration = 86400; // int.Parse(configuration["Cache:AbsoluteExpiration"]);
        }

        public void RegisterServices(IServiceCollection services)
        {
            RegisterCacheService<ScoreBatResponseModel>(services);
        }

        private void RegisterCacheService<TValue>(IServiceCollection services)
            where TValue : class
        {
            services.AddTransient<ICacheService<TValue>, InMemoryCacheService<TValue>>(x =>
                new InMemoryCacheService<TValue>(
                    x.GetRequiredService<IMemoryCache>(),
                    absoluteExpiration));
        }
    }
}
