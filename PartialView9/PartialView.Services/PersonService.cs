using PartialView.Domain.Entities;
using PartialView.Repositories.Interfaces;
using PartialView.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonDAO _personDAO;
        public PersonService(IPersonDAO personDAO) // DI
        {
            _personDAO = personDAO;
        }
        public async Task<IEnumerable<Person>> GetAllPersonAsync(JobType type)
        {
            
            return await _personDAO.GetAllPersonAsync(type);
            
        }
    }
}
