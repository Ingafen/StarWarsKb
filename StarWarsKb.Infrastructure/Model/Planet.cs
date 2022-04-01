using System.Collections.Generic;
using StarWars.Infrastructure.Model;

namespace StarWarsKb.Infrastructure.Model
{
    public class Planet : IStarWarsEntity
    {
        public string Name { get; set; }
        public IList<Character> Residents { get; set; }
        public int StarWarId { get; set; }
    }
}