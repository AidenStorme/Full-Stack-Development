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

        public Task AddAsync(Beer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Beer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Beer?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Beer>?> GetAllAsync()
        {
            return await _context.Beers.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Beer>> GetBeersAsync()
        {
            return await _context.Beers.AsNoTracking()
                .Include(b => b.BrouwernrNavigation) // Link leggen naar je brewery tabel
                .Include(b => b.SoortnrNavigation) // Link leggen naar je variety tabel
                .ToListAsync();
        }
        public async Task<IEnumerable<Beer>> GetBeersByAlcohol(decimal percentage)
        {
            try
            {
                return await _context.Beers
                .Where(b => b.Alcohol == percentage)
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)

                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Beer>> GetBeersByBrewery(int brouwerId)
        {
            try
            {
                return await _context.Beers
                .Where(b => b.Brouwernr == brouwerId)
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)

                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task UpdateAsync(Beer entity)
        {
            throw new NotImplementedException();
        }
    }
}
