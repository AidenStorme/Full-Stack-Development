using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiVacation.Domain.Entities;

namespace TuiVacation.Domain.Data
{
    public class TuiVacationDbContext : DbContext
    {
        public TuiVacationDbContext(DbContextOptions<TuiVacationDbContext> options) : base(options)
        {
        }

        public DbSet<Vacation> Vacations { get; set; }
    }
}