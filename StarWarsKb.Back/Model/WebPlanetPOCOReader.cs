using StarWarsKb.Back.Model.POCO;

namespace StarWarsKb.Back.Model
{
    public class WebPlanetPOCOReader : WebPOCOReader<PlanetPOCO>, IWebReader<PlanetPOCO>
    {
        public WebPlanetPOCOReader() : base("planets")
        {
            
        }
    }
}