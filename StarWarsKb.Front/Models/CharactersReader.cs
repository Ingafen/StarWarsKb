using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using StarWarsKb.Infrastructure.Model;
using StarWarsKb.Infrastructure.Services;

namespace StarWarsKb.Front.Models
{
    public class CharactersReader : ICharactersReader
    {
        private readonly IHttpReader _httpReader;
        private readonly IParamService _paramService;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public CharactersReader(IHttpReader httpReader, IParamService paramService)
        {
            _httpReader = httpReader;
            _paramService = paramService;
        }

        public Task<IList<Character>> Characters()
        {
            return GetAllAsync();
        }

        public async Task<Character> GetById(int id)
        {
            var str = await _httpReader.GetJsonStringByUrl(_paramService.GetParam("SWKB-back-address")+$@"/Characters/{id}");

            if (str == _httpReader.ErrorMessage) return await new Task<Character>(() => new Character());

            return JsonSerializer.Deserialize<Character>(str, _options);
        }

        private async Task<IList<Character>> GetAllAsync()
        {
            var str = await _httpReader.GetJsonStringByUrl(_paramService.GetParam("SWKB-back-address") + @"/Characters");

            if (str == _httpReader.ErrorMessage) return await new Task<IList<Character>>(() => new List<Character>());

            return JsonSerializer.Deserialize<IList<Character>>(str, _options);
        }
    }
}