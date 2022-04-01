using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWarsKb.Front.Models;

namespace StarWarsKb.Front.Controllers
{
    public class SwkbController : Controller
    {
        private readonly ICharactersReader _charactersReader;
        private readonly IReportReader _reportReader;

        public SwkbController(ICharactersReader charactersReader, IReportReader reportReader)
        {
            _reportReader = reportReader;
            _charactersReader = charactersReader;
        }

        // GET
        public async Task<ViewResult> Characters()
        {
            return View(await _charactersReader.Characters());
        }

        public async Task<IActionResult> CharacterInfo(int id)
        {
            return View(await _charactersReader.GetById(id));
        }

        public async Task<ViewResult> Report()
        {
            return View(await _reportReader.GetReport());
        }
    }
}