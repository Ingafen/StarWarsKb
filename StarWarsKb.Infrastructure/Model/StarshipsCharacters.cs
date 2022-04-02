using System.Text.Json.Serialization;

namespace StarWarsKb.Infrastructure.Model
{
    public class StarshipsCharacters
    {
        public int StarshipId { get; set; }
        [JsonIgnore]
        public Starship Starship { get; set; }
        public int CharacterId { get; set; }
        [JsonIgnore]
        public Character Character { get; set; }
    }
}