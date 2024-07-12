namespace ReactFootball.Services.Models.Contracts
{
    public interface IRequest
    {
        string Url { get; set; }

        string CacheKey { get; }
    }
}
