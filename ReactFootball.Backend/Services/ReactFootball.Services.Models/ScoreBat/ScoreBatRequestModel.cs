using ReactFootball.Services.Models.Contracts;

namespace ReactFootball.Services.Models.ScoreBat
{
    public class ScoreBatRequestModel : IRequest
    {
        public string Token { get; set; }

        public string Url { get; set; }

        public string CacheKey => Token.GetHashCode().ToString();
    }
}
