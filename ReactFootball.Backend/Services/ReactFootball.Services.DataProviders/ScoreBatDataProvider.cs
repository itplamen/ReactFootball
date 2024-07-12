using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

using ReactFootball.Services.DataProviders.Contracts;
using ReactFootball.Services.DataProviders.Utilities;
using ReactFootball.Services.Models.ScoreBat;

namespace ReactFootball.Services.DataProviders
{
    public class ScoreBatDataProvider : IDataProvider<ScoreBatRequestModel, ScoreBatResponseModel>
    {
        private readonly HttpClient httpClient;

        public ScoreBatDataProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ScoreBatResponseModel> GetData(ScoreBatRequestModel request)
        {
            var queryString = QueryStringBuilder.Build(request);
            string url = QueryHelpers.AddQueryString(request.Url, queryString);

            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ScoreBatResponseModel>(content);

            return result;
        }
    }
}
