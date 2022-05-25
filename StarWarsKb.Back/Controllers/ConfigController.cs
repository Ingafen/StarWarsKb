using Microsoft.AspNetCore.Mvc;
using StarWarsKb.Back.Model;

namespace StarWarsKb.Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : Controller
    {
        private readonly IClearService _clearService;
        private readonly IUpdateService _updateService;

        public ConfigController(IClearService clearService, IUpdateService updateService)
        {
            _clearService = clearService;
            _updateService = updateService;
        }
        
        [HttpGet]
        [Route("[action]")]
        public string Clear()
        {
            _clearService.ClearDB();
            return "Success";
        }
        
        [HttpGet]
        [Route("[action]")]
        public string Update()
        {
            _updateService.CreateData();
            return "Success!";
        }

        [HttpGet]
        [Route("[action]")]
        public string Alive()
        {
            return "I'm still alive!";
        }
    }
}  