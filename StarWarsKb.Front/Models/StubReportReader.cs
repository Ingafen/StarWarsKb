using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Front.Models
{
    public class StubReportReader : IReportReader
    {
        public async Task<IList<ReportEntity>> GetReport()
        {
            var report = new List<ReportEntity>();
            var characters = (new StubCharactersReader()).Characters().Result;
            
            foreach (var character in characters)
            {
                report.Add(new ReportEntity
                {
                    CharacterName = character.Name,
                    Starships = character.Starships,
                    TotalCapacity = 10
                });
            }
            
            return await new Task<IList<ReportEntity>>(()=> report);
        }
    }
}