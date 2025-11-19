using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiVacation.Domain.Entities;
using TuiVacation.Repository.Interfaces;
using TuiVacation.Services.Interfaces;

namespace TuiVacation.Services
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
