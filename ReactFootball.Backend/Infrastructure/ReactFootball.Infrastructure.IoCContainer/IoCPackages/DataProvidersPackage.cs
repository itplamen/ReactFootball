using System.Net.Http;

using Microsoft.Extensions.DependencyInjection;

using ReactFootball.Infrastructure.IoCContainer.Contracts;
using ReactFootball.Services.Cache.Contracts;
using ReactFootball.Services.DataProviders;
using ReactFootball.Services.DataProviders.Contracts;
using ReactFootball.Services.Models.Contracts;
using ReactFootball.Services.Models.ScoreBat;

namespace ReactFootball.Infrastructure.IoCContainer.IoCPackages
{
    public sealed class DataProvidersPackage : IPackage
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(new HttpClient());

            services.AddTransient<ScoreBatDataProvider>();

            RegisterDecorator<ScoreBatRequestModel, ScoreBatResponseModel, ScoreBatDataProvider>(services);
        }

        private void RegisterDecorator<TRequest, TResponse, TDataProvider>(IServiceCollection services)
            where TRequest : IRequest
            where TResponse : class
            where TDataProvider : IDataProvider<TRequest, TResponse>
        {
            services.AddTransient<IDataProvider<TRequest, TResponse>, CacheDataProvider<TRequest, TResponse>>(x =>
            new CacheDataProvider<TRequest, TResponse>(
                x.GetRequiredService<ICacheService<TResponse>>(),
                x.GetRequiredService<TDataProvider>()));
        }
    }
}
