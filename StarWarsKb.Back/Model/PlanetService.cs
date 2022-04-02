using StarWarsKb.Back.Model.POCO;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public class PlanetService : IPlanetService
    {
        public Planet CreateFromPOCO(PlanetPOCO planetPoco)
        {
            var planet = new Planet
            {
                Climate = planetPoco.climate,
                Gravity = planetPoco.gravity,
                Name = planetPoco.name,
                Terrain = planetPoco.terrain,
                SurfaceWater = planetPoco.surface_water,
                Diameter = int.TryParse(planetPoco.diameter, out var diameter) ? diameter : -1,
                Population = int.TryParse(planetPoco.population, out var population) ? population : -1,
                OrbitalPeriod = int.TryParse(planetPoco.orbital_period, out var orbital) ? orbital : -1,
                RotationPeriod = int.TryParse(planetPoco.rotation_period, out var rotation) ? rotation : -1,
                StarWarId = planetPoco.id
            };

            return planet;
        }
    }
}