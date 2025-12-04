using AutoMapper;
using Beer9.AutoMapper;
using Beer9.Domain.Entities;
using Beer9.Services.Interfaces;
using Beer9.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Identity.Client;

namespace Beer9.Controllers
{
    public class BeerController : Controller
    {
        private readonly IBeerService _beerService;
        private IService<Brewery> _breweryService;
        private readonly IMapper _mapper;

        public BeerController(IBeerService beerService, IMapper mapper, IService<Brewery> breweryService)
        {
            _beerService = beerService;
            _mapper = mapper;
            _breweryService = breweryService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var lstBeers = await _beerService.GetAllAsync();
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

        public IActionResult GetBeersByAlcohol()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> GetBeersByAlcohol(BeerPercentageVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var beers = await _beerService.GetAllBeersAlcoholAsync(model.AlcoholPercentage!.Value);
                model.Beers = _mapper.Map<List<BeerVM>>(beers);

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,
                    "Er ging iets mis bij het ophalen van de bieren. Probeer het later opnieuw.");
            }
            return View();
        }

        public async Task<IActionResult> GetBeersByBrewery()
        {
            try 
            {
                ViewBag.lstBrouwer = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam"
                );

                return View();
            }
            catch (Exception ex)
            {
                // Toon een foutmelding als er iets misgaat
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de brouwerijen: " + ex.Message);
            } return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetBeersByBrewery(int? brouwerId)
        {
            if (brouwerId == null)
            {
                return NotFound();
            }
            try
            {
                var bierList = await _beerService.GetBeersByBrewery
                    (Convert.ToInt16(brouwerId));

                ViewBag.lstBrouwer = new SelectList(await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam",
                    brouwerId
                );

                List<BeerVM> listVM = _mapper.Map<List<BeerVM>>(bierList);
                return View(listVM);
            }
            catch (Exception ex)
            {
                // Toon een foutmelding als er iets misgaat
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de bieren: " + ex.Message);
            } return View();
        }

        public async Task<IActionResult> GetBeersByBreweryVM()
        {
            try
            {
                BreweryBeersVM breweryBeersVM = new BreweryBeersVM();
                breweryBeersVM.Breweries = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam"
                );

                return View(breweryBeersVM);
            }
            catch (Exception ex)
            {
                // Toon een foutmelding als er iets misgaat
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de brouwerijen: " + ex.Message);
            }
            return View();
        }

    }
}
