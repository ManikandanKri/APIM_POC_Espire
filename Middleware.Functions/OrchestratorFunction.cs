using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;

public class OrchestratorFunction
{
    [Function("OrchestratorFunction")]
    public async Task Run(
        [OrchestrationTrigger] TaskOrchestrationContext context)
    {
        if(context!= null)
        {
        string eventId = context.GetInput<string>();
        int maxRetries = 3;

        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            // Fetch data from Source
            string payload = await context.CallActivityAsync<string>(
                "FetchActivity",
                eventId);

            // Validate payload
            bool isValid = await context.CallActivityAsync<bool>(
                "ValidateActivity",
                payload);

            if (isValid)
            {
                // Push to Destination
                await context.CallActivityAsync(
                    "PushActivity",
                    payload);

                return;
            }

            // Exponential backoff retry
            TimeSpan delay = TimeSpan.FromMinutes(Math.Pow(2, attempt));
            await context.CreateTimer(context.CurrentUtcDateTime.Add(delay), CancellationToken.None);
        
        }

        // Move to DLQ after max retries.Use when all attempts fail.
        await context.CallActivityAsync(
            "MoveToDLQ",
            eventId);
        }
    }
}
