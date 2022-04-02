using StarWarsKb.Back.Model.POCO;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public interface ICharacterService
    {
        Character CreateFromPOCO(CharacterPOCO characterPoco);
    }
}