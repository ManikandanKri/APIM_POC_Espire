using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;

public class ValidateActivity
{
    private readonly ValidationService _validationService;

    // Dependency Injection
    public ValidateActivity(ValidationService validationService)
    {
        _validationService = validationService;
    }

    [Function("ValidateActivity")]
    public bool Run(
        [ActivityTrigger] string payload)
    {
        return _validationService.Validate(payload);
    }
}
