using AutoMapper;
using Beer9.AutoMapper;
using Beer9.Services.Interfaces;
using Beer9.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Beer9.Controllers
{
    public class BeerController : Controller
    {
        private readonly IBeerService _beerService;
        private readonly IMapper _mapper;

        public BeerController(IBeerService beerService, IMapper mapper)
        {
            _beerService = beerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var lstBeers = await _beerService.GetAllBeersAsync();
                List<BeerVM> adultVMs = null;


                if (lstBeers != null)
                {
                    adultVMs = _mapper.Map<List<BeerVM>>(lstBeers); // gebruik automapper
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
