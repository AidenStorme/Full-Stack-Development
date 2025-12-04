using Microsoft.AspNetCore.Mvc.Rendering;

namespace Beer9.ViewModels
{
    public class BreweryBeersVM
    {
        public int? BreweryNumber { get; set; }
        public IEnumerable<SelectListItem> Breweries { get; set; } // IEnumerable<SelectListItem> -> betekent maak een <select> met allemaal opties
        public IEnumerable<BeerVM> Beers { get; set; }
    }
}
