using System.Collections.Generic;

namespace StarWarsKb.Infrastructure.Model
{
    public class ReportEntity
    {
        public ReportEntity()
        {
            Starships = new List<Starship>();
        }
        
        public string CharacterName { get; set; }
        public IList<Starship> Starships { get; set; }
        public long TotalCapacity { get; set; }
    }
}