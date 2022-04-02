using System.Collections.Generic;
using System.Linq;
using StarWarsKb.Back.Model.POCO;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public class UpdateService : IUpdateService
    {
        private readonly IWebReader<CharacterPOCO> _characterWebReader;
        private readonly IWebReader<StarshipPOCO> _starshipWebReader;
        private readonly IWebReader<PlanetPOCO> _planetWebReader;
        private readonly ICharacterService _characterService;
        private readonly IStarshipService _starshipService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Character> _charactersRepository;
        private readonly IBaseRepository<Starship> _starshipsRepository;
        private readonly IBaseRepository<Planet> _planetsRepository;
        private readonly IPlanetService _planetService;
        public UpdateService(IWebReader<CharacterPOCO> characterWebReader,
            IWebReader<StarshipPOCO> starshipWebReader, IWebReader<PlanetPOCO> planetWebReader,
            ICharacterService characterService, IStarshipService starshipService, 
            IUnitOfWork unitOfWork, IBaseRepository<Character> charactersRepository, 
            IBaseRepository<Starship> starshipsRepository, IBaseRepository<Planet> planetsRepository, 
            IPlanetService planetService)
        {
            _characterWebReader = characterWebReader;
            _starshipWebReader = starshipWebReader;
            _planetWebReader = planetWebReader;
            _characterService = characterService;
            _starshipService = starshipService;
            _unitOfWork = unitOfWork;
            _charactersRepository = charactersRepository;
            _starshipsRepository = starshipsRepository;
            _planetsRepository = planetsRepository;
            _planetService = planetService;
        }

        void RunDataOperations(bool saveIfTrueUpdateIfFalse)
        {
            IList<CharacterPOCO> characterPocos = new List<CharacterPOCO>();
            var empty = "EMPTY";
            
            for (var i = 1; i < 90; i++)
            {
                var item = _characterWebReader.ReadEntityWithId(i);
                if (item.name != empty)
                {
                    characterPocos.Add(item);
                }
            }

            IList<PlanetPOCO> planetPocos = new List<PlanetPOCO>();
            for (var i = 1; i < 65; i++)
            {
                var item = _planetWebReader.ReadEntityWithId(i);
                if (item.name != empty)
                {
                    planetPocos.Add(item);
                }
            }

            IList<StarshipPOCO> starshipPocos = new List<StarshipPOCO>();
            for (int i = 1; i < 75; i++)
            {
                var item = _starshipWebReader.ReadEntityWithId(i);
                if (item.name != empty)
                {
                    starshipPocos.Add(item);
                }
            }

            IList<Character> characters = new List<Character>();
            foreach (var characterPoco in characterPocos)
            {
                if (characterPoco.name != empty)
                {
                    characters.Add(_characterService.CreateFromPOCO(characterPoco));
                }
            }

            IList<Starship> starships = new List<Starship>();
            foreach (var starshipPoco in starshipPocos)
            {
                if (starshipPoco.name != empty)
                {
                    starships.Add(_starshipService.CreateFromPOCO(starshipPoco));
                }
            }

            IList<Planet> planets = new List<Planet>();
            foreach (var planetPoco in planetPocos)
            {
                planets.Add(_planetService.CreateFromPOCO(planetPoco));
            }

            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].HomeWorldId != 0)
                {
                    characters[i].HomeWorld = planets.First(x => x.StarWarId == characters[i].HomeWorldId);
                    characters[i].HomeWorldId = 0;
                }
            }

            if (saveIfTrueUpdateIfFalse)
            {
                _planetsRepository.Save(planets);
               _charactersRepository.Save(characters);
               _starshipsRepository.Save(starships);
            }
            
            _unitOfWork.SaveChanges();
        }
        public void CreateData()
        {
            RunDataOperations(true);
        }
        public void RunUpdate()
        {
            RunDataOperations(false);
        }
    }
}