using System;

using Microsoft.Extensions.Caching.Memory;
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

        public CachePackage()
        {
            absoluteExpiration = int.Parse(Environment.GetEnvironmentVariable("AbsoluteExpiration", EnvironmentVariableTarget.Process));
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
