using Microsoft.EntityFrameworkCore;
using TUI_TravelNET9.Domain.Data;
using TUI_TravelNET9.Domain.Entities;
using TUI_TravelNET9.Repositories;
using TUI_TravelNET9.Repositories.Interfaces;
using TUI_TravelNET9.Services;
using TUI_TravelNET9.Services.Intefaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb")
);

builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IHotelDAO, HotelDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Seed demo data bij opstarten
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HotelDbContext>();

    if (!db.Hotels.Any())
    {
        db.Hotels.AddRange(
            new Hotel { Id = 1, NameHotel = "Hotel Example", City = "Bruges", Stars = 4, Score = 8.5, Benefit = "Free breakfast", Photo = "hotel1.jpg", Country = CountryType.Coast }
        );

        db.SaveChanges();
    }
}

app.Run();
