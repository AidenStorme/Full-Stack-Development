using PartialView.Domain.EntitiesDB;
using PartialView.Repositories.Interfaces;
using PartialView.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Services
{
    public class PersonDBService : IPersonDBService
    {
        private readonly IPersonDBDAO _personDBDAO;

        public PersonDBService(IPersonDBDAO personDBDAO)
        {
            _personDBDAO = personDBDAO;
        }
        public async Task<IEnumerable<Adult>> GetAllAdultAsync()
        {
            return await _personDBDAO.GetAdultsAsync();
        }
    }
}
