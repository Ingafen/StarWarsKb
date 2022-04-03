using System.Collections.Generic;
using System.Linq;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public class ReportGenerator : IReportGenerator
    {
        private readonly IBaseRepository<Character> _characterRepository;
        private readonly IBaseRepository<Starship> _starshipRepository;

        public ReportGenerator(IBaseRepository<Character> characterRepository, IBaseRepository<Starship> starshipRepository)
        {
            _characterRepository = characterRepository;
            _starshipRepository = starshipRepository;
        }
        
        public IList<ReportEntity> GetReport()
        {
            IList<Character> characterWithShips = _characterRepository
                .GetAll()
                .Where(x => x.StarshipCharacters.Count > 0)
                .ToList();

            IList<ReportEntity> report = new List<ReportEntity>();

            foreach (var character in characterWithShips)
            {
                var reportEntity = new ReportEntity
                {
                    CharacterName = character.Name
                };
                foreach (var starshipId in character.StarshipCharacters.Select(x => x.StarshipId))
                {
                    reportEntity.Starships.Add(_starshipRepository.GetById(starshipId));
                }

                reportEntity.TotalCapacity = reportEntity.Starships.Sum(x => x.CargoCapacity);
                report.Add(reportEntity);
            }

            return report.OrderByDescending(x => x.TotalCapacity).Take(10).ToList();
        }
    }
}