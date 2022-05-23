using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public class CharactersRepository : IBaseRepository<Character>
    {
        private readonly ApplicationDbContext _context;

        public CharactersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Character> GetAll()
        {
            return _context.Characters
                .Include(c => c.StarshipCharacters)
                .Include(cc => cc.HomeWorld)
                .ToList();
        }
        public Character GetById(int id)
        {
            return _context.Characters
                .Include(c => c.StarshipCharacters)
                .Include(cc => cc.HomeWorld)
                .First(x => x.StarWarId == id);
        }
        public void Save(Character c)
        {
            _context.Characters.Add(c);
        }
        public void Save(IList<Character> characters)
        {
            _context.Characters.AddRange(characters);
        }

        public void DeleteAll()
        {
            var all = _context.Characters.ToList();
            _context.Characters.RemoveRange(all);
        }
    }
}