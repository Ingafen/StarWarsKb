using StarWars.Infrastructure.Model;

namespace StarWars.Front.Models;

public interface ICharactersReader
{
    Task<IList<Character>> Characters();
    Task<Character> GetById(int id);
}