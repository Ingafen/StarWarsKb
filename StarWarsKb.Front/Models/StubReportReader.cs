using StarWars.Infrastructure.Model;

namespace StarWars.Front.Models;

public class StubReportReader : IReportReader
{
    public async Task<IList<Character>> GetReport()
    {
        Task<IList<Character>> characters = new StubCharactersReader().Characters();
        return await characters;
    }
}