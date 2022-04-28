using System.Collections.Generic;
using StarWarsKb.Infrastructure.Services;

namespace StarWarsKb.Back.Model
{
    public class StubParamService : IParamService
    {
        private readonly IDictionary<string, string> _env;
        public StubParamService()
        {
            _env = new Dictionary<string, string>
            {
                {"SWKB-back-cs","Host=localhost;Database=StarWarsKb;Username=postgres;Password=454119;Port=5432"}
            };
        }
        
        public string GetParam(string paramName)
        {
            return _env[paramName];
        }
    }
}