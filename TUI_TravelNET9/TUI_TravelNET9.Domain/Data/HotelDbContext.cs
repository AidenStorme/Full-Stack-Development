using Microsoft.EntityFrameworkCore;
using TUI_TravelNET9.Domain.Entities;

namespace TUI_TravelNET9.Domain.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}