using Microsoft.AspNetCore.Mvc;
using StarWarsKb.Front.Models;

namespace StarWarsKb.Front.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IBackEndCaller _backEndCaller;

        public SettingsController(IBackEndCaller backEndCaller)
        {
            _backEndCaller = backEndCaller;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Clear()
        {
            var t = _backEndCaller.Clear();
            //t.Wait(60000);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Update()
        {
            var t = _backEndCaller.Update();
            //t.Wait(60000);
            return RedirectToAction("Index", "Home");
        }
    }
}