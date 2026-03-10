using PartialView.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Repositories.Interfaces
{
    public interface IPersonDAO // Zorgen dat deze public is
    {
        Task<IEnumerable<Person>> GetAllPersonAsync(JobType type);

    }
}
