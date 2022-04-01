using System.Net.Http;
using System.Text.Json;
using StarWarsKb.Infrastructure.Services.POCO;

namespace StarWarsKb.Infrastructure.Services
{
    public abstract class WebPOCOReader<T> where T : IStarWarPOCOEntity
    {
        private HttpClient _client;
        private const string BaseUrl = @"https://swapi.dev/api/";
        private string subURL { get; }

        protected WebPOCOReader(string sub)
        {
            _client = new HttpClient();
            subURL = sub;
        }

        public T ReadEntityWithId(int id)
        {
            var task = _client.GetStringAsync($"{BaseUrl}{subURL}/{id}/");

            var poco = JsonSerializer.Deserialize<T>(task.Result);

            return poco;
        }
    }
}