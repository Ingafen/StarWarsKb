using System.Threading.Tasks;

namespace StarWarsKb.Front.Models
{
    public interface IBackEndCaller
    {
        Task<string> Update();
        Task<string> Clear();
    }
}