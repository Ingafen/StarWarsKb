using System.Text.Json;
using StarWars.Infrastructure.Services.POCO;

namespace StarWars.Infrastructure.Services;

public abstract class WebPOCOReader<T> where T: IStarWarPOCOEntity
{
    private HttpClient _client;
    private const string BaseUrl = @"https://swapi.dev/api/";
    private string subURL { get; }

    protected WebPOCOReader(string sub)
    {
        _client = new HttpClient();
        subURL = sub;
    }

    public T? ReadEntityWithId(int id)
    {
        var task = _client.GetStringAsync($"{BaseUrl}{subURL}/{id}/");

        var poco = JsonSerializer.Deserialize<T>(task.Result);

        return poco;
    }
}