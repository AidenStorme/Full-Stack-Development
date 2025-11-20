using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PartialView.Services.Interfaces;
using PartialView9.ViewModels;

namespace PartialView9.Controllers
{
    public class PersonSortingController : Controller
    {
        private readonly IPersonDBService _personDBService;
        private readonly IMapper _mapper; // automapper toevoegen

        public PersonSortingController(IPersonDBService personDBService, IMapper mapper)
        {
            _mapper = mapper; // automapper toevoegen
            _personDBService = personDBService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var lstAdults = await _personDBService.GetAllAdultAsync();
                List<AdultVM> adultVMs = null;


                if (lstAdults != null)
                {
                    adultVMs = _mapper.Map<List<AdultVM>>(lstAdults); // gebruik automapper
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
