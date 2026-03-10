using BeerschopNET9_Identity.Extention;
using BeerschopNET9_Identity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeerschopNET9_Identity.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            
            HttpContext.Session.SetObject("mySession", 
                new SessionVM
                {
                    Date = DateTime.Now,
                    Company = "VIVES"
                });

            return View();
        }
    }
}
