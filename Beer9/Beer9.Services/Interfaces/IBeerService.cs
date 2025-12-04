using Beer9.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer9.Services.Interfaces
{
    public interface IBeerService
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync();
    }
}
