using Newtonsoft.Json;

namespace ReactFootball.Services.Models.ScoreBat
{
    public class ScoreBatVideoResponseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("embed")]
        public string Embed { get; set; }
    }
}
