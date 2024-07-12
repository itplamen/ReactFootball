using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ReactFootball.Services.DataProviders.Contracts;
using ReactFootball.Services.Models.ScoreBat;

namespace ReactFootball.Web.Services
{
    public class ScoreBatService
    {
        private readonly IDataProvider<ScoreBatRequestModel, ScoreBatResponseModel> dataProvider;

        public ScoreBatService(IDataProvider<ScoreBatRequestModel, ScoreBatResponseModel> dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        [Function("ScoreBatService")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "scorebat")] HttpRequest req)
        {
            var request = new ScoreBatRequestModel();

            var response = await dataProvider.GetData(request);

            return new OkObjectResult(response);
        }
    }
}
