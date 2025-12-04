using Beer9.Domain.Data;
using Beer9.Domain.Entities;
using Beer9.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer9.Repositories
{
    public class BeerDAO : IBeerDAO
    {
        private readonly BeerDbContext _context;

        public BeerDAO(BeerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Beer>> GetBeersAsync()
        {
            return await _context.Beers.AsNoTracking()
                .Include(b => b.BrouwernrNavigation) // Link leggen naar je brewery tabel
                .Include(b => b.SoortnrNavigation) // Link leggen naar je variety tabel
                .ToListAsync();
        }
    }
}
