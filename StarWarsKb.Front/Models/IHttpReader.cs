namespace StarWars.Front.Models;

public interface IHttpReader
{
    Task<string> GetJsonStringByUrl(string url);
    string ErrorMessage { get; }
}