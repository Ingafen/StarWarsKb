using StarWarsKb.Back.Model.POCO;

namespace StarWarsKb.Back.Model
{
    public class WebStarshipPOCOReader : WebPOCOReader<StarshipPOCO>, IWebReader<StarshipPOCO>
    {
        public WebStarshipPOCOReader() : base("starships")
        {
        }
    }
}