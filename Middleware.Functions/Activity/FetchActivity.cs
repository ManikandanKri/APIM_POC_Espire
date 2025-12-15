using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;

public class FetchActivity
{
    private readonly SourceApiService _sourceApiService;

    // Dependency Injection
    public FetchActivity(SourceApiService sourceApiService)
    {
        _sourceApiService = sourceApiService;
    }

    [Function("FetchActivity")]
    public async Task<string> Run(
        [ActivityTrigger] string eventId)
    {
        return await _sourceApiService.FetchDataAsync(eventId);
    }
}
