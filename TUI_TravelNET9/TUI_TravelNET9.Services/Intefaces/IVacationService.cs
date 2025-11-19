using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiVacation.Domain.Entities;

namespace TuiVacation.Services.Interfaces
{
    public interface IVacationService
    {
        Task<IEnumerable<Vacation>> GetAllVacationsAsync(CountryType type);
    }
}