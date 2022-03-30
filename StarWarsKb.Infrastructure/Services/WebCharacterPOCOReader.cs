using StarWars.Infrastructure.Services.POCO;

namespace StarWars.Infrastructure.Services;

public class WebCharacterPOCOReader : WebPOCOReader<CharacterPOCO>, IWebReader<CharacterPOCO>
{
    public WebCharacterPOCOReader() : base("people")
    {
        
    }
    
    
}