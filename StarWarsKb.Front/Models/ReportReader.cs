using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Front.Models
{
    public class ReportReader : IReportReader
    {
        private readonly IHttpReader _httpReader;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        public ReportReader(IHttpReader httpReader)
        {
            _httpReader = httpReader;
        }
        
        public async Task<IList<ReportEntity>> GetReport()
        {
            var str = await _httpReader.GetJsonStringByUrl(@"https://localhost:5001/ShipReport");

            if (str == _httpReader.ErrorMessage)
            {
                return await new Task<IList<ReportEntity>>(() => new List<ReportEntity>());
            }

            return JsonSerializer.Deserialize<IList<ReportEntity>>(str, _options);
        }
    }
}