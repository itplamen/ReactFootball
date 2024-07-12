using System.Threading.Tasks;

namespace ReactFootball.Services.Cache.Contracts
{
    public interface ICacheService<TValue>
        where TValue : class
    {
        Task Set(string key, TValue value);

        Task<TValue> Get(string key);
    }
}
