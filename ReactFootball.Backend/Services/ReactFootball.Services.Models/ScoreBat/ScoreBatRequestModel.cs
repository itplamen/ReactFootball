using Newtonsoft.Json;

using ReactFootball.Services.Models.Contracts;

namespace ReactFootball.Services.Models.ScoreBat
{
    public class ScoreBatRequestModel : IRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        public string Url { get; set; }

        public string CacheKey => Token.GetHashCode().ToString();
    }
}
