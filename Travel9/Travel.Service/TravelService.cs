using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Service.Integrations.CountryApi.DTO;
using Travel.Service.Interfaces;

namespace Travel.Service
{
    public class TravelService : ITravelService
    {
        private readonly IConfiguration _configure;
        private readonly string apiBaseUrl;

        public TravelService(IConfiguration configuration)
        {
            _configure = configuration;
            apiBaseUrl = _configure["WebAPIBaseUrl"];
        }

        public async Task<List<CountryItem>?> GetCountriesAsync()
        {

            try
            {


                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiBaseUrl))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        var root = JsonConvert.DeserializeObject<CountryApiDto>(apiResponse);
                        //   ViewBag.CountryLst = countries != null ? countries.Select(x => new SelectListItem { Text = x.LocalizedName, Value = x.ID }).ToList() : null;
                        var items = root?.Data ?? new List<CountryItem>();
                        return items;

                    }
                }

            }
            catch (HttpRequestException ex)
            {
                // catch problem
                return null;

            }
        }
    }
}
