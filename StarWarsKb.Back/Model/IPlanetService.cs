using StarWarsKb.Back.Model.POCO;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public interface IPlanetService
    {
        Planet CreateFromPOCO(PlanetPOCO planetPoco);
    }
}