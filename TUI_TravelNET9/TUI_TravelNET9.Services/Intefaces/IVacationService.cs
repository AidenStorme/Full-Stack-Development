using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI_TravelNET9.Domain.Entities;

namespace TUI_TravelNET9.Services.Intefaces
{
    public interface IVacationService
    {
        Task<IEnumerable<Vacation>> GetAllVacationsAsync(CountryType type);
    }
}