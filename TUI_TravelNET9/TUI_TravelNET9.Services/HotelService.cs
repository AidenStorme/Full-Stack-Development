using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI_TravelNET9.Domain.Entities;
using TUI_TravelNET9.Repositories.Interfaces;
using TUI_TravelNET9.Services.Intefaces;

namespace TUI_TravelNET9.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelDAO _hotelDao;

        public HotelService(IHotelDAO hotelDao)
        {
            _hotelDao = hotelDao;
        }

        public Task<IEnumerable<Hotel>> GetAllHotelsAsync(CountryType type)
        {
            // Delegate to the DAO implementation which queries the DbContext.
            return _hotelDao.GetAllVacationsAsync(type);
        }
    }
}
