using StarWarsKb.Back.Model;
using StarWarsKb.Back.Model.POCO;
using Xunit;

namespace StarWarsKb.UnitTests.Back.Model
{
    public class WebCharacterPOCOReaderTests
    {
        [Fact(Skip="Id may be changed")]
        public void CanGetPeopleObjectFromAPI()
        {
            var reader = new WebCharacterPOCOReader();

            CharacterPOCO characterPoco = reader.ReadEntityWithId(2);
            
            Assert.Equal("C-3PO", characterPoco.name);
        }

        [Fact]
        public void ReturnNullIf404()
        {
            var reader = new WebCharacterPOCOReader();

            CharacterPOCO characterPoco = reader.ReadEntityWithId(777);
            
            Assert.Equal("EMPTY", characterPoco.name);
        }
    }
}