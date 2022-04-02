using System;
using System.Net.Http;
using System.Text.Json;
using StarWarsKb.Back.Model.POCO;

namespace StarWarsKb.Back.Model
{
    public abstract class WebPOCOReader<T> where T : IStarWarPOCOEntity, new()
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

            T entity;
            
            try
            {
                entity = JsonSerializer.Deserialize<T>(task.Result);
                entity.id = id;
            }
            catch (Exception exc )
            {
                entity = new T {name = "EMPTY"};
            }
            
            return entity;
        }
    }
}