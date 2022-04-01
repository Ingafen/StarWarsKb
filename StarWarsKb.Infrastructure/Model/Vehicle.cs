using StarWars.Infrastructure.Model;

namespace StarWarsKb.Infrastructure.Model
{
    public class Vehicle : IStarWarsEntity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int StarWarId { get; set; }
    }
}