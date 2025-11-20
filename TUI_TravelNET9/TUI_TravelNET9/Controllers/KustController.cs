using Microsoft.AspNetCore.Mvc;

namespace TUI_TravelNET9.Controllers;

public class KustController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}