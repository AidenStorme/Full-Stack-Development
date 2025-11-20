using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUI_TravelNET9.Domain.Data;
using TUI_TravelNET9.Domain.Entities;
using TUI_TravelNET9.Repositories.Interfaces;

namespace TUI_TravelNET9.Repositories
{
    public class HotelDAO : IHotelDAO
    {
        private readonly HotelDbContext _context;

        public HotelDAO(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetAllVacationsAsync(CountryType type)
        {
            return await _context.Hotels.Where(v => v.Country == type).ToListAsync();
        }
    }
}

