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
    public class VacationService : IVacationService
    {
        private readonly IVacationDAO _vacationDAO;

        public VacationService(IVacationDAO vacationDAO)
        {
            _vacationDAO = vacationDAO;
        }

        public async Task<IEnumerable<Vacation>> GetAllVacationsAsync(CountryType type)
        {
            return await _vacationDAO.GetAllVacationsAsync(type);
        }
    }
}
