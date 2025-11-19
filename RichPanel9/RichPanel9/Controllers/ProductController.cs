using Microsoft.AspNetCore.Mvc;
using RichPanel9.ViewModels;

namespace RichPanel9.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ProductVM product)
        {
            return View("Richoutput", product);
        }
    }
}
