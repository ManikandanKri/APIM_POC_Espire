using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;

public class PushActivity
{
    private readonly DestinationApiService _destinationApiService;

    // Dependency Injection
    public PushActivity(DestinationApiService destinationApiService)
    {
        _destinationApiService = destinationApiService;
    }

    [Function("PushActivity")]
    public async Task Run(
        [ActivityTrigger] string payload)
    {
        await _destinationApiService.PushAsync(payload);
    }
}
