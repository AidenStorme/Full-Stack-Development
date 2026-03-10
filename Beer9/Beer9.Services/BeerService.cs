using Beer9.Domain.Entities;
using Beer9.Repositories.Interfaces;
using Beer9.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer9.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerDAO _beerDAO;

        public BeerService(IBeerDAO beerDAO)
        {
            _beerDAO = beerDAO;
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
            return await _beerDAO.GetAllAsync();
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAlcoholAsync(int value)
        {
            return await _beerDAO.GetBeersByAlcohol(value);
        }

        public async Task<IEnumerable<Beer>> GetBeersByBrewery(int brouwerId)
        {
            return await _beerDAO.GetBeersByBrewery(brouwerId);
        }

        public Task UpdateAsync(Beer entity)
        {
            throw new NotImplementedException();
        }
    }
}