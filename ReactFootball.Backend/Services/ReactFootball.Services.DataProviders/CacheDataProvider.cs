using System.Threading.Tasks;

using ReactFootball.Services.Cache.Contracts;
using ReactFootball.Services.DataProviders.Contracts;
using ReactFootball.Services.Models.Contracts;

namespace ReactFootball.Services.DataProviders
{
    public class CacheDataProvider<TRequest, TResponse> : IDataProvider<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : class
    {
        private readonly ICacheService<TResponse> cacheService;
        private readonly IDataProvider<TRequest, TResponse> decorated;

        public CacheDataProvider(ICacheService<TResponse> cacheService, IDataProvider<TRequest, TResponse> decorated)
        {
            this.cacheService = cacheService;
            this.decorated = decorated;
        }

        public async Task<TResponse> GetData(TRequest request)
        {
            var cacheData = await cacheService.Get(request.CacheKey);

            if (cacheData == null)
            {
                var response = await decorated.GetData(request);
                await cacheService.Set(request.CacheKey, response);

                return response;
            }

            return cacheData;
        }
    }
}
