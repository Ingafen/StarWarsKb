using StarWars.Infrastructure.Model;

namespace StarWarsKb.Infrastructure.Model
{
    public class Spec : IStarWarsEntity
    {
        public string Name { get; set; }
        public string Classification { get; set; }
        public int StarWarId { get; set; }
    }
}