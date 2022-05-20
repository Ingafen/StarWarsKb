using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public class ClearService : IClearService
    {
        private readonly IBaseRepository<Character> _characterRepository;
        private readonly IBaseRepository<Planet> _planetRepository;
        private readonly IBaseRepository<Starship> _starshipRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClearService(IUnitOfWork unitOfWork,
            IBaseRepository<Character> characterRepository,
            IBaseRepository<Planet> planetRepository,
            IBaseRepository<Starship> starshipRepository)
        {
            _characterRepository = characterRepository;
            _unitOfWork = unitOfWork;
            _planetRepository = planetRepository;
            _starshipRepository = starshipRepository;
        }

        public void ClearDB()
        {
            _characterRepository.DeleteAll();
            _planetRepository.DeleteAll();
            _starshipRepository.DeleteAll();
            _unitOfWork.SaveChanges();
        }
    }
}