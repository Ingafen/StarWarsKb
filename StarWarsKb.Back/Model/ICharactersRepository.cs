using StarWars.Infrastructure.Model;

namespace StarWars.Back.Model;

public interface ICharactersRepository
{
    IList<Character> GetAll();
    Character GetById(int id);
}