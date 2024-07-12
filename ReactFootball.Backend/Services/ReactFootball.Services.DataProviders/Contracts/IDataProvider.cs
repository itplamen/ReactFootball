using System.Threading.Tasks;

using ReactFootball.Services.Models.Contracts;

namespace ReactFootball.Services.DataProviders.Contracts
{
    public interface IDataProvider<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : class
    {
        Task<TResponse> GetData(TRequest request);
    }
}
