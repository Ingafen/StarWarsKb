using StarWarsKb.Infrastructure.Services.POCO;

namespace StarWarsKb.Infrastructure.Services
{
    public interface IWebReader<T> where T : IStarWarPOCOEntity
    {
        T ReadEntityWithId(int id);
    }
}