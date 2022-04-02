using System.Collections.Generic;
using System.Text.Json.Serialization;
using StarWars.Infrastructure.Model;

namespace StarWarsKb.Infrastructure.Model
{
    public class Planet : IStarWarsEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public IList<Character> Residents { get; set; }
        public int StarWarId { get; set; }
        
        public int RotationPeriod { get; set; }
        public int OrbitalPeriod { get; set; }
        public int Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string SurfaceWater { get; set; }
        public int Population { get; set; }
    }
}