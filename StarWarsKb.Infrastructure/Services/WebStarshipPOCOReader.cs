using StarWarsKb.Infrastructure.Services.POCO;

namespace StarWarsKb.Infrastructure.Services
{
    public class WebStarshipPOCOReader : WebPOCOReader<StarshipPOCO>, IWebReader<StarshipPOCO>
    {
        public WebStarshipPOCOReader() : base("starships")
        {
        }
    }
}