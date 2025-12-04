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
        public async Task<IEnumerable<Beer>> GetAllBeersAsync()
        {
            return await _beerDAO.GetBeersAsync();
        }
    }
}