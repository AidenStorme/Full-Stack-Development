using Microsoft.AspNetCore.Mvc;
using SendMail9.ViewModels;
using SendMail9.Services.Interfaces;
using SendMail9.Domain;

namespace SendMail9.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(OrderInputVM model)
    {
        if (ModelState.IsValid)
        {
            await _orderService.SendOrderConfirmationAsync(model.Email);
            ViewBag.Message = "Orderbevestiging succesvol verzonden!";
            return View();
        }
        return View(model);
    }

    public IActionResult DemoOrder()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> DemoOrder(OrderInputVM model)
    {
        if (ModelState.IsValid)
        {
            await _orderService.SendOrderConfirmationAsync(model.Email);
            ViewBag.Message = "E-mail succesvol verzonden naar " + model.Email;
            return View();
        }
        return View(model);
    }
    
    [HttpGet]
    public IActionResult DemoOrderAttachment()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> DemoOrderAttachment(OrderInputVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var order = CreateDemoOrder(model.Name, model.Email);

        try
        {
            await _orderService.SendOrderConfirmationAsync(order);
            ViewBag.Message = $"Order bevestiging met producten succesvol verzonden naar {model.Email}";
            return View();
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Er is een fout opgetreden: {ex.Message}";
            return View(model);
        }
    }

    private Order CreateDemoOrder(string customerName, string customerEmail)
    {
        return new Order
        {
            Id = new Random().Next(1000, 9999),
            CustomerName = customerName,
            CustomerEmail = customerEmail,
            OrderDate = DateTime.Now,
            Products = new List<Product>
            {
                new Product { Id = 1, Name = "Duvel", Quantity = 6, Price = 2.50m },
                new Product { Id = 2, Name = "Jupiler", Quantity = 12, Price = 1.20m },
                new Product { Id = 3, Name = "La Chouffe", Quantity = 4, Price = 3.00m },
                new Product { Id = 4, Name = "Westmalle Tripel", Quantity = 6, Price = 2.80m }
            }
        };
    }
}