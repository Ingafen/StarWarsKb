using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Front.Models
{
    public interface IReportReader
    {
        public Task<IList<Character>> GetReport();
    }
}