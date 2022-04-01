using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Front.Models
{
    public class StubReportReader : IReportReader
    {
        public async Task<IList<Character>> GetReport()
        {
            Task<IList<Character>> characters = new StubCharactersReader().Characters();
            return await characters;
        }
    }
}