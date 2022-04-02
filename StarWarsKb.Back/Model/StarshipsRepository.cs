using System.Collections.Generic;
using System.Linq;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public class StarshipsRepository : IBaseRepository<Starship>
    {
        private readonly ApplicationDbContext _dbContext;

        public StarshipsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IList<Starship> GetAll()
        {
            return _dbContext.Starships.ToList();
        }

        public Starship GetById(int id)
        {
            return _dbContext.Starships.First(x => x.StarWarId == id);
        }

        public void Save(Starship s)
        {
            _dbContext.Starships.Add(s);
        }

        public void Save(IList<Starship> starships)
        {
            _dbContext.Starships.AddRange(starships);
        }
    }
}