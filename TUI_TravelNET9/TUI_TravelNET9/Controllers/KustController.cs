using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TUI_TravelNET9.Services.Intefaces;
using TUI_TravelNET9.Domain.Entities;
using TUI_TravelNET9.ViewModels;

namespace TUI_TravelNET9.Controllers;

public class KustController : Controller
{
    private readonly IHotelService _hotelService;
    
    public KustController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }
    public async Task<IActionResult> Index(CountryType country)
    {
        try
        {
            var hotelList = await _hotelService.GetAllHotelsAsync(country);

            if (hotelList != null)
            {
                List<VacationVM> hotelVMs = new List<VacationVM>();
                foreach (var hotel in hotelList)
                {
                    var hotelVm = new VacationVM();
                    // map Hotel properties to VacationVM
                    hotelVm.NameHotel = hotel.NameHotel;
                    hotelVm.Stars = hotel.Stars;
                    hotelVm.Score = hotel.Score;
                    hotelVm.Facilities = hotel.Facilities;
                    hotelVm.Photo = hotel.Photo;
                    hotelVm.Country = hotel.Country;
                    hotelVMs.Add(hotelVm);
                }
                return View(hotelVMs);
            }
        }
        catch (Exception ex)
        {
            // Log the error and return a friendly message
            ModelState.AddModelError("", $"Er is een fout opgetreden bij het ophalen van de hotels voor {country}: {ex.Message}");
        }

        return View();
    }
}