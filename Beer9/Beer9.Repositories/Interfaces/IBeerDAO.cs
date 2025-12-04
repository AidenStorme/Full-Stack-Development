using Beer9.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer9.Repositories.Interfaces
{
    public interface IBeerDAO : IDAO<Beer>
    {
        Task<IEnumerable<Beer>> GetBeersByAlcohol(decimal percentage);
        Task<IEnumerable<Beer>> GetBeersByBrewery(int brouwerId);
    }
}
