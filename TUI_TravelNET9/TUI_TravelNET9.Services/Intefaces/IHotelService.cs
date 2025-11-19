using System.Collections.Generic;
using System.Threading.Tasks;
using TUI_TravelNET9.Domain.Entities;

namespace TUI_TravelNET9.Services.Intefaces
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync(CountryType type);
    }
}

