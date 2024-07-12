using System.Collections.Generic;

using Newtonsoft.Json;

namespace ReactFootball.Services.Models.ScoreBat
{
    public class ScoreBatResponseModel
    {
        [JsonProperty("response")]
        public IEnumerable<ScoreBatMatchResponseModel> Matches { get; set; }
    }
}
