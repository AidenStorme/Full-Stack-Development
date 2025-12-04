using Microsoft.EntityFrameworkCore;
using PartialView.Domain.Entities;
using PartialView.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Services.Interfaces
{
    public interface IPersonService // Niet vergeten public te maken
    {
        Task<IEnumerable<Person>> GetAllPersonAsync(JobType type);
    }
}
