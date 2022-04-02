using StarWarsKb.Back.Model.POCO;

namespace StarWarsKb.Back.Model
{
    public class WebCharacterPOCOReader : WebPOCOReader<CharacterPOCO>, IWebReader<CharacterPOCO>
    {
        public WebCharacterPOCOReader() : base("people")
        {

        }
    }
}