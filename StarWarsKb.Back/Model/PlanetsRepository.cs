using System.Collections.Generic;
using System.Linq;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public class PlanetsRepository : IBaseRepository<Planet>
    {
        private readonly ApplicationDbContext _dbContext;

        public PlanetsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Planet> GetAll()
        {
            return _dbContext.Planets.ToList();
        }

        public Planet GetById(int id)
        {
            return _dbContext.Planets.First(x => x.StarWarId == id);
        }

        public void Save(Planet entity)
        {
            _dbContext.Planets.Add(entity);
        }
        public void Save(IList<Planet> entities)
        {
            _dbContext.Planets.AddRange(entities);
        }

        public void DeleteAll()
        {
            var all = _dbContext.Planets.ToList();
            _dbContext.Planets.RemoveRange(all);
        }
    }
}