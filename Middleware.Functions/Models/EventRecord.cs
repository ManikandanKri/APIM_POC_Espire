public class EventRecord
{
    public string EventId { get; set; }
    public string Payload { get; set; }
    public string Status { get; set; }   // Pending, Validated, Failed, DLQ
    public int RetryCount { get; set; }
    public DateTime LastUpdated { get; set; }
}
