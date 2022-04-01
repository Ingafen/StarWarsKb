using StarWarsKb.Infrastructure.Services;
using StarWarsKb.Infrastructure.Services.POCO;

namespace StarWars.Infrastructure.Services
{
    public class WebCharacterPOCOReader : WebPOCOReader<CharacterPOCO>, IWebReader<CharacterPOCO>
    {
        public WebCharacterPOCOReader() : base("people")
        {

        }


    }
}