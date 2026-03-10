using Microsoft.AspNetCore.Mvc;

namespace Beer9.Controllers
{
    public class BreweryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
