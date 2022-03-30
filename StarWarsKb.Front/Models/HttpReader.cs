
namespace StarWars.Front.Models;

public class HttpReader : IHttpReader
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpReader(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public string ErrorMessage => "Error";

    public async Task<string> GetJsonStringByUrl(string apiUrl)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, apiUrl);
        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(requestMessage);

        Task<string> task;
        
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            await using var contentStream =
                await httpResponseMessage.Content.ReadAsStreamAsync();

            var sr = new StreamReader(contentStream);

            task = sr.ReadToEndAsync();
        }
        else
        {
            task = new Task<string>(()=> ErrorMessage);
        }
        
        return await task;
    }
}