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
    public class BreweryDAO : IDAO<Brewery>
    {
        private readonly BeerDbContext _context;
        public Task AddAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }

        public Task<Brewery?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Brewery>?> GetAllAsync()
        {
            return await _context.Breweries.AsNoTracking().ToListAsync();
        }

        public Task UpdateAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }
    }
}
