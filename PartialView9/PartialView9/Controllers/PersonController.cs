using Microsoft.AspNetCore.Mvc;
using PartialView.Domain.Entities;
using PartialView.Services.Interfaces;
using PartialView9.ViewModels;

namespace PartialView9.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        public async Task<IActionResult> Index(JobType type)
        {
            try
            {
                var persons = await _personService.GetAllPersonAsync(type);

                if (persons != null)
                {
                    List<PersonVM> personVMs = new List<PersonVM>();
                    foreach (var person in persons)
                    {
                        var personVM = new PersonVM();
                        // later we use an automapper
                        personVM.Naam = person.Naam;
                        personVM.Voornaam = person.Voornaam;
                        personVM.EnrollDate = person.EnrollDate;
                        personVM.ImagePath = person.ImagePath;
                        personVMs.Add(personVM);
                    }
                    return View(personVMs);
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
