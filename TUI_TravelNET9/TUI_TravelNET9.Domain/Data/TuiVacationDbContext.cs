using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI_TravelNET9.Domain.Entities;

namespace TUI_TravelNET9.Domain.Data
{
    public class TuiVacationDbContext : DbContext
    {
        public TuiVacationDbContext(DbContextOptions<TuiVacationDbContext> options) : base(options)
        {
        }

        public DbSet<Vacation> Vacations { get; set; }
    }
}