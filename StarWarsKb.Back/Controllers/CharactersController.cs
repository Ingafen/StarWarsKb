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
        private readonly ICharactersRepository _charactersRepository;

        public CharactersController(ICharactersRepository charactersRepository)
        {
            _charactersRepository = charactersRepository;
        }

        [HttpGet]
        public IList<Character> Get() => _charactersRepository.GetAll();

        [HttpGet("{id}")]
        public Character Get(int id) => _charactersRepository.GetById(id);
    }
}