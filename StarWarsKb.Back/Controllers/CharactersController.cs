using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StarWarsKb.Back.Model;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly IBaseRepository<Character> _charactersRepository;

        public CharactersController(IBaseRepository<Character> charactersRepository)
        {
            _charactersRepository = charactersRepository;
        }

        [HttpGet]
        public IList<Character> Get() => _charactersRepository.GetAll();

        [HttpGet("{id}")]
        public Character Get(int id)
        {
            var byId = _charactersRepository.GetById(id);
            return byId;
        }
    }
}