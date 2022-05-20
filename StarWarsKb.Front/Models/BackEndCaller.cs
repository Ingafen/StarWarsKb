using System.Threading.Tasks;
using StarWarsKb.Infrastructure.Services;

namespace StarWarsKb.Front.Models
{
    public class BackEndCaller : IBackEndCaller
    {
        private readonly IHttpReader _httpReader;
        private readonly IParamService _paramService;

        public BackEndCaller(IHttpReader httpReader, IParamService paramService)
        {
            _httpReader = httpReader;
            _paramService = paramService;
        }
        
        public async Task<string> Update()
        {
            return await CallBackEnd(@"/Config/Update/");
        }

        private async Task<string> CallBackEnd(string address)
        {
            var url = _paramService.GetParam("SWKB-back-address") + address;
            var str = await _httpReader.GetJsonStringByUrl(url);

            if (str == _httpReader.ErrorMessage)
            {
                return await new Task<string>(() => "Failed");
            }

            return str;
        }

        public async Task<string> Clear()
        {
            return await CallBackEnd(@"/Config/Clear/");
        }
    }
}