using System.Collections.Generic;
using StarWars.Infrastructure.Model;

namespace StarWarsKb.Infrastructure.Model
{
    public class Starship : IStarWarsEntity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public long CostInCredits { get; set; }
        public int Lenght { get; set; }
        public string MaxAtmospheringSpeed { get; set; }
        public int CrewCount { get; set; }
        public int PassengersCount { get; set; }
        public long CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string HyperdriveRating { get; set; }
        public string MGLT { get; set; }
        public string StarshipClass { get; set; }
        public int StarWarId { get; set; }
        public IList<StarshipsCharacters> StarshipsCharacters { get; set; }
    }
}