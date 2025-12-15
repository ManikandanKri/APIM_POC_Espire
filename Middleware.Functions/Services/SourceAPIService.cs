
public class SourceApiService
{
    private readonly HttpClient _httpClient;

    public SourceApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> FetchDataAsync(string eventId)
    {
        var response = await _httpClient.GetAsync($"/source/data/{eventId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
