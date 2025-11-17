using Microsoft.AspNetCore.Mvc;
using Stars.ViewModels;

namespace Stars.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FilmVM filmVM)
        {
            if (filmVM != null)
            {
                filmVM.Stars += 1; // Je kan hier de properties van je ViewModel nemen en er iets meedoen
                // ^ Dit zal niet de nieuwe waarde tonen, omdat je server na submit niet meer de data terug geeft.
                // ^ Hij zal gewoon de oude data terug plaatsen hieronder zieje hoe je die cleared en dan nieuwe data mee geeft.
            }

            // Twee manier om dit op te lossen
            // Manier 1:
            ModelState.Clear(); // Alle properties worden gecleared
            // Manier 2:
            ModelState.Remove("Stars"); // Specifieke property legen

            return View(filmVM); // Je moet dan wel een view returnen met het nu gemaakte filmVM
        }
    }
}
