using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Front.Models
{
    public class StubCharactersReader : ICharactersReader
    {
        private readonly IList<Character> _list;

        public StubCharactersReader()
        {
            _list = new List<Character>
            {
                new Character()
                {
                    StarWarId = 1, Name = "Test Luke Skywalker",
                    Height = 172, Mass = 77, HairColor = "blond",
                    SkinColor = "fair", EyeColor = "blue", BirthYear = "19BBY",
                    Gender = "male", HomeWorld = new Planet {Name = "Tatooine"},
                    Films = new List<Film>
                    {
                        new Film {Title = "The Empire Strikes Back", EpisodeId = 5},
                        new Film {Title = "Revenge of the Sith", EpisodeId = 3}
                    },
                    Species = new List<Spec>
                    {
                        new Spec {Name = "human", Classification = "mammal"}
                    },
                    Vehicles = new List<Vehicle>
                    {
                        new Vehicle {Name = "Snowspeeder", Model = "t-47 airspeeder"},
                        new Vehicle {Name = "Imperial Speeder Bike", Model = "74-z speeder bike"}
                    },
                    Starships = new List<Starship>
                    {
                        new Starship {Name = "X-wing", Model = "T-65 X-wing"},
                        new Starship {Name = "Imperial shuttle", Model = "Lambda-class T-4a shuttle"}
                    }
                },
                new Character
                {
                    StarWarId = 2, Name = "Boba Fett", Height = 183, Mass = 78.2d, HairColor = "black",
                    SkinColor = "fair", EyeColor = "brown", BirthYear = "31.5BBY",
                    Gender = "Male", HomeWorld = new Planet {Name = "Kamino"},
                    Films = new List<Film>
                    {
                        new Film {Title = "The Empire Strikes Back", EpisodeId = 5},
                        new Film {Title = "Return of the Jedi", EpisodeId = 6},
                        new Film {Title = "Attack of the Clones", EpisodeId = 2}
                    },
                    Species = new List<Spec>(),
                    Vehicles = new List<Vehicle>(),
                    Starships = new List<Starship>
                    {
                        new Starship {Name = "Slave 1", Model = "Firespray-31-class patrol and attack"}
                    }
                }
            };
        }

        public async Task<IList<Character>> Characters()
        {
            return _list.ToList();
        }

        public async Task<Character> GetById(int id)
        {
            var character = _list.First(x => x.StarWarId == id);
            return character;
        }
    }
}