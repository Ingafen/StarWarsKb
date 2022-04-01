namespace StarWarsKb.Infrastructure.Model
{
    public class StarshipsCharacters
    {
        public int StarshipId { get; set; }
        public Starship Starship { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}