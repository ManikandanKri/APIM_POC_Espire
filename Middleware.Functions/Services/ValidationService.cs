public class ValidationService
{
    public bool Validate(string payload)
    {
        if (string.IsNullOrEmpty(payload))
            return false;

        // Example business rule
        return payload.Contains("mandatoryField");
    }
}
