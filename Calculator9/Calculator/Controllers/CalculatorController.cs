using Calculator.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CalculatorVM calculatorVM)
        {
            return View(calculatorVM);
        }

        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(CalculatorVM calculatorVM)
        {
            var total = calculatorVM.Getal1 + calculatorVM.Getal2;

            ViewBag.Total = total; // Controller en View, in een ViewBag(soort vuilbak) mag je alles smijten
            return View(calculatorVM);
        }
    }
}