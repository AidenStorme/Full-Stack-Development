using Microsoft.AspNetCore.Mvc;
using PartialView.Services.Interfaces;
using PartialView9.ViewModels;

namespace PartialView9.Controllers
{
    public class PersonDBController : Controller
    {
        private readonly IPersonDBService _personDBService;

        public PersonDBController(IPersonDBService personDBService)
        {
            _personDBService = personDBService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var persons = await _personDBService.GetAllAdultAsync();


                if (persons != null)
                {
                    List<AdultVM> adultVMs = new List<AdultVM>();
                    foreach (var adult in persons)
                    {
                        var adultVM = new AdultVM();
                        // later we use an automapper
                        adultVM.FirstName = adult.FirstName;
                        adultVM.LastName = adult.LastName;
                        adultVM.EnrollDate = adult.EnrollDate;
                        adultVM.DepartmentName = adult.Department.DepartmentName;
                        adultVMs.Add(adultVM);
                    }
                    return View(adultVMs);
                }

            }
            catch (Exception ex)
            {
                // Log de fout en geef een vriendelijke foutmelding terug
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de bedrijven: " + ex.Message);

            }
            return View();
        }
    }
}
