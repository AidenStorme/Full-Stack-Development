using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using Travel.Service.Integrations.CountryApi.DTO;
using Travel9.ViewModels;

namespace Travel9.Controllers
{
    public class CountryController : Controller
    {
        private IConfiguration _Configure;
        private string? apiBaseUrl;

        public CountryController(IConfiguration configuration) // DI
        {
            _Configure = configuration; // Deze waarde kan aan de appsettings file
            apiBaseUrl = _Configure.GetValue<String>("WebAPIBaseUrl"); // Hier haal je eigenlijk de waarde op die in appsettings staat
        }

        public async Task<IActionResult> Index()
        {
            var countryVM = new CountryVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiBaseUrl))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        var root = JsonConvert.DeserializeObject<CountryApiDto>(apiResponse); // Dit is je convert "deserialize"
                        var items = root?.Data ?? new List<CountryItem>(); // Hij zal al de data in een list items steken als die leeg is maakt hij een nieuwe, lege lijst
                        countryVM.CountryList = items.Select(c => new SelectListItem // Hier zitten enkel country objecten in
                        { Text = c.Name, Value = c.Code }).ToList(); // LINQ
                        // ^ .ToList() betekent eigenlijk execute, hij zal de lijst aanmaken.
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                // Optionally log the error or set an error message in the view model
            }
            return View(countryVM);
        }
    }
}
