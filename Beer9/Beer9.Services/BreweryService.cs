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
    public class BreweryService : IService<Brewery>
    {
        private readonly IDAO<Brewery> _breweryDAO;
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
            return await _breweryDAO.GetAllAsync();
        }

        public Task UpdateAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }
    }
}
