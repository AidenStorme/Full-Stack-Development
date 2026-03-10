using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Travel.Service.Integrations.CountryApi.DTO;
using Travel.Service.Interfaces;
using Travel9.ViewModels;

namespace Travel9.Controllers
{
    public class TravelController : Controller
    {

        private readonly ITravelService _travelService;

        public TravelController(ITravelService travelService) // DI
        {
            _travelService = travelService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new TravelVM
            {
                CountryList =
                await BuildCountryListAsync()
            };


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TravelVM travelVM, string? calculateDays = null)
        {
            // Call DB
            travelVM.CountryList = await BuildCountryListAsync();

            return View(travelVM);
        }
        public async Task<IActionResult> IndexWithDatePicker()
        {
            var vm = new TravelDatePickerVM
            {
                CountryList = await BuildCountryListAsync()
            };


            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> IndexWithDatePicker(TravelDatePickerVM traverDatePickerVM)
        {
            // Call DB
            traverDatePickerVM.CountryList = await BuildCountryListAsync();

            return View(traverDatePickerVM);
        }

        private async Task<List<SelectListItem>> BuildCountryListAsync()
        {
            try
            {
                var countries = await _travelService.GetCountriesAsync() ?? new List<CountryItem>();
                return countries
                    .OrderBy(c => c.Name)
                    .Select(c => new SelectListItem { Text = c.Name, Value = c.Code })
                    .DefaultIfEmpty(new SelectListItem { Text = "-- geen landen beschikbaar --", Value = "", Disabled = true, Selected = true })
                    .ToList();
            }
            catch
            {
                return new()
                {
                    new SelectListItem { Text = "-- landen laden mislukt --", Value = "", Disabled = true, Selected = true }
                };
            }

        }
    }
}
