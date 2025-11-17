using Intro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Intro.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Default is an action always Get-request
        // [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost] // Is used to post data. Kan enkel aangesproken worden via een post request (dus niet via de URL)
        public IActionResult Register(string txtName, string txtFirstName)
        {
            return View();
        }

        public IActionResult RegisterNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterNew(PersonVM personVM) // Model binding --> geeft alle velden mee
        {
            if (ModelState.IsValid) // Serverside control, kijkt per property of die geldig is
            {
                // Call DB
                return View("Thanks", personVM);

                // --- Verschillende manieren om een view te returnen ---
                // return View() -- returned view met dezelfde naam als de action (RegisterNew)
                // return View ("ActionName")
                // return View(obj)
                // return View ("ActionName", obj)
            }
            else
            {
                return View();
            }
        }

        public IActionResult Thanks(PersonVM personVM) // Thanks pagina maken
        {
            return View(personVM); // Geven hier een object mee van PersonVM
        }
        // Compileren : ctrl+shift+b
        // Code mooi zetten : ctrl+k+d
    }
}