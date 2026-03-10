using Microsoft.AspNetCore.Mvc;

namespace Register9.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
