using StarWars.Infrastructure.Model;

namespace StarWarsKb.Infrastructure.Model
{
    public class Film : IStarWarsEntity
    {
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public int StarWarId { get; set; }
    }
}