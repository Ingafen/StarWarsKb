using StarWars.Infrastructure.Model;

namespace StarWars.Front.Models;

public interface IReportReader
{
    public Task<IList<Character>> GetReport();
}