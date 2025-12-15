using System.Text;

public class DestinationApiService
{
    private readonly HttpClient _httpClient;

    public DestinationApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task PushAsync(string payload)
    {
        var content = new StringContent(payload, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/destination/submit", content);
        response.EnsureSuccessStatusCode();
    }
}
