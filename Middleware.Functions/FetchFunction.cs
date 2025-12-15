using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask.Client;

public class FetchFunction
{
    [Function("FetchFunction")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "fetch/{eventId}")]
        HttpRequestData req,
        string eventId,
        [DurableClient] DurableTaskClient durableClient)
    {
        await durableClient.ScheduleNewOrchestrationInstanceAsync(
            "OrchestratorFunction",
            eventId);

        var response = req.CreateResponse(HttpStatusCode.Accepted);
        await response.WriteStringAsync("Orchestration started");
        return response;
    }
}
