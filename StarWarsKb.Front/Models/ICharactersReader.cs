using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Front.Models
{
    public interface ICharactersReader
    {
        Task<IList<Character>> Characters();
        Task<Character> GetById(int id);
    }
}