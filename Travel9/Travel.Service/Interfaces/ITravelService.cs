using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Service.Integrations.CountryApi.DTO;

namespace Travel.Service.Interfaces
    // Dit is een contract
{
    public interface ITravelService // Dit moet public zijn anders kan die nergens gebruikt worden
    {
        Task<List<CountryItem>?> GetCountriesAsync();
    }
}
