using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using StarWars.Infrastructure.Model;

namespace StarWarsKb.Infrastructure.Model
{
    public class Character : IStarWarsEntity
    {
        public Character()
        {
            Films = new List<Film>();
            Species = new List<Spec>();
            Vehicles = new List<Vehicle>();
            Starships = new List<Starship>();
        }
        
        [NotMapped]
        public List<Starship> Starships { get; set; }

        public string Name { get; set; }
        public int Height { get; set; }
        public double Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public Planet HomeWorld { get; set; }
        public int HomeWorldId { get; set; }
        
        [NotMapped]
        public List<Film> Films { get; set; }
        
        [NotMapped]
        public List<Spec> Species { get; set; }
        
        [NotMapped]
        public List<Vehicle> Vehicles { get; set; }
        public int StarWarId { get; set; }
        public IList<StarshipsCharacters> StarshipCharacters { get; set; }
    }
}