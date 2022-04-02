using StarWarsKb.Back.Model.POCO;

namespace StarWarsKb.Back.Model
{
    public interface IWebReader<T> where T : IStarWarPOCOEntity
    {
        T ReadEntityWithId(int id);
    }
}