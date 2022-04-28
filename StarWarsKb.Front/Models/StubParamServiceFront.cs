using System.Collections.Generic;
using StarWarsKb.Infrastructure.Services;

namespace StarWarsKb.Front.Models
{
    public class StubParamServiceFront : IParamService
    {
        public string GetParam(string paramName)
        {
            var dict = new Dictionary<string, string>()
            {
                {"SWKB-back-address", @"https://localhost:5001"}
            };
            return dict[paramName];
        }
    }
}