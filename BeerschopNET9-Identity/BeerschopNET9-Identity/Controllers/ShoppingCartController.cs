using AutoMapper;
using BeerschopNET9_Identity.Extention;
using BeerschopNET9_Identity.ViewModels;
using Beershop.Domain.Entities;
using Beershop.Services;
using BeerShop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BeerschopNET9_Identity.Controllers
{
    public class ShoppingCartController : Controller
    {
        private const string CartKey = "ShoppingCart";

        public async Task<IActionResult> Index()
        {
            var cart = GetShoppingCart();
            return View(cart);
        }

        private ShoppingCartVM? GetShoppingCart()
        {
            var vm = HttpContext.Session.GetObject<ShoppingCartVM>(CartKey);

            return vm;
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int beerNumber)
        {
            if (beerNumber <= 0)
            {
                TempData["Error"] = "Ongeldig product.";
                return RedirectToAction(nameof(Index));
            }
            var carts = GetShoppingCart();
            carts.Carts.RemoveAll(c => c.BeerNumber == beerNumber);
            HttpContext.Session.SetObject(CartKey, carts);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCount(int beerNumber, int count)
        {
            if (beerNumber <= 0)
            {
                TempData["Error"] = "Ongeldig product.";
                return RedirectToAction(nameof(Index));
            }

            if (count < 1) count = 1;

            var vm = GetShoppingCart();

            var item = vm?.Carts?.FirstOrDefault(x => x.BeerNumber == beerNumber);
            if (item != null)
            {
                item.Count = count;
                SaveShoppingCart(vm);
            }
            return RedirectToAction(nameof(Index));
        }

        private void SaveShoppingCart(ShoppingCartVM vm)
        {
            HttpContext.Session.SetObject(CartKey, vm);
        }


        //[Authorize(Roles = "Customer")]
        //[HttpGet]
        //public IActionResult Payment()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    if (string.IsNullOrWhiteSpace(userId))
        //        return Unauthorized();

        //    var cartVm = GetShoppingCart();

        //    if (cartVm?.Carts == null || !cartVm.Carts.Any())
        //    {
        //        TempData["Error"] = "Je winkelmand is leeg.";
        //        return RedirectToAction(nameof(Index));
        //    }

        //    try
        //    {

        //    } 
        //    catch
        //    {

        //    }
        //}
    }
}
