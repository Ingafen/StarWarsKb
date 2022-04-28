using System;
using StarWarsKb.Back.Model;
using Xunit;

namespace StarWarsKb.UnitTests.Back.Model
{
    public class UpdateServiceDebugTests
    {
        [Fact(Skip = "Delete")]
        public void DebugTest()
        {
            var characterWebReader = new WebCharacterPOCOReader();
            var planetWebReader = new WebPlanetPOCOReader();
            var starshipsWebReader = new WebStarshipPOCOReader();
            var characterService = new CharacterService();
            var starshipService = new StarshipService();
            var dbContext = new ApplicationDbContext(new StubParamService());
            var unitOfWork = new UnitOfWork(dbContext);
            var characterRepository = new CharactersRepository(dbContext);
            var starshipsRepository = new StarshipsRepository(dbContext);
            var planetRepository = new PlanetsRepository(dbContext);
            var planetService = new PlanetService();

            var updateService = new UpdateService(characterWebReader,
                starshipsWebReader, planetWebReader, characterService,
                starshipService, unitOfWork, characterRepository,
                starshipsRepository, planetRepository, planetService);

            updateService.CreateData();
        }
    }
}