using Moq;
using StarWarsKb.Back.Model;
using StarWarsKb.Back.Model.POCO;
using StarWarsKb.Infrastructure.Model;
using Xunit;

namespace StarWarsKb.UnitTests.Back.Model
{
    public class UpdateServiceTests
    {
        [Fact]
        public void TestOfTest()
        {
            Assert.Equal(4, 2+2);
        }

        private readonly Mock<IWebReader<CharacterPOCO>> _mockCharacterWebReader;
        private readonly Mock<IWebReader<StarshipPOCO>> _mockStarshipWebReader;
        private readonly Mock<IWebReader<PlanetPOCO>> _mockPlanetWebReader;
        private readonly Mock<ICharacterService> _mockCharacterService;
        private readonly Mock<IStarshipService> _mockStarshipService;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IBaseRepository<Character>> _mockCharacterRepository;
        private readonly Mock<IBaseRepository<Starship>> _mockStarshipsRepository;
        private readonly Mock<IBaseRepository<Planet>> _mockPlanetsRepository;
        private readonly Mock<IPlanetService> _mockPlanetService;
        
        public UpdateServiceTests()
        {
            _mockCharacterWebReader = new Mock<IWebReader<CharacterPOCO>>();
            _mockStarshipWebReader = new Mock<IWebReader<StarshipPOCO>>();
            _mockPlanetWebReader = new Mock<IWebReader<PlanetPOCO>>();
            _mockCharacterService = new Mock<ICharacterService>();
            _mockStarshipService = new Mock<IStarshipService>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockCharacterRepository = new Mock<IBaseRepository<Character>>();
            _mockStarshipsRepository = new Mock<IBaseRepository<Starship>>();
            _mockPlanetsRepository = new Mock<IBaseRepository<Planet>>();
            _mockPlanetService = new Mock<IPlanetService>();
            
            IUpdateService updateService = new UpdateService(_mockCharacterWebReader.Object, 
                _mockStarshipWebReader.Object,
                _mockPlanetWebReader.Object,
                _mockCharacterService.Object,
                _mockStarshipService.Object,
                _mockUnitOfWork.Object,
                _mockCharacterRepository.Object,
                _mockStarshipsRepository.Object,
                _mockPlanetsRepository.Object,
                _mockPlanetService.Object);
            
            updateService.CreateData();
        }

        [Fact(Skip = "")]
        public void PlanetReaderCalledAtLeastOnce()
        {
            _mockPlanetWebReader.Verify(x => x.ReadEntityWithId(It.IsAny<int>()), Times.AtLeast(1));
        }

        [Fact(Skip = "")]
        public void StarshipWebReaderCalledAtLeastOnce()
        {
            _mockStarshipWebReader.Verify(x => x.ReadEntityWithId(It.IsAny<int>()), Times.AtLeast(1));
        }

        [Fact(Skip = "")]
        public void CharacterWebReaderCalledAtLeastOnce()
        {
            _mockCharacterWebReader.Verify(x => x.ReadEntityWithId(It.IsAny<int>()), Times.AtLeast(1));
        }
    }
}