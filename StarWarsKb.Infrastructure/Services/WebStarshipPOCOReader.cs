using StarWars.Infrastructure.Services.POCO;

namespace StarWars.Infrastructure.Services;

public class WebStarshipPOCOReader : WebPOCOReader<StarshipPOCO>, IWebReader<StarshipPOCO>
{
    public WebStarshipPOCOReader() : base("starships")
    {
        
    }
}