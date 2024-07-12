using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ReactFootball.Services.Models.ScoreBat
{
    public class ScoreBatMatchResponseModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("competition")]
        public string Competition { get; set; }

        [JsonProperty("matchviewUrl")]
        public string MatchviewUrl { get; set; }

        [JsonProperty("competitionUrl")]
        public string CompetitionUrl { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("videos")]
        public IEnumerable<ScoreBatVideoResponseModel> Videos { get; set; }
    }
}
