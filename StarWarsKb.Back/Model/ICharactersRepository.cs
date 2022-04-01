using System.Collections.Generic;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public interface ICharactersRepository
    {
        IList<Character> GetAll();
        Character GetById(int id);
    }
}