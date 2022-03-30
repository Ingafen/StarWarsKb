using StarWars.Infrastructure.Services.POCO;

namespace StarWars.Infrastructure.Services;

public interface IWebReader<T> where T: IStarWarPOCOEntity
{
    T? ReadEntityWithId(int id);
}