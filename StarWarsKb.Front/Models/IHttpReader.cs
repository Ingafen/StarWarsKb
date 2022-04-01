using System.Threading.Tasks;

namespace StarWarsKb.Front.Models
{
    public interface IHttpReader
    {
        Task<string> GetJsonStringByUrl(string url);
        string ErrorMessage { get; }
    }
}