using System;

namespace StarWarsKb.Infrastructure.Services
{
    public class ParamService : IParamService
    {
        public string GetParam(string paramName)
        {
            var variable = Environment.GetEnvironmentVariable(paramName);
            return variable;
        }
    }
}