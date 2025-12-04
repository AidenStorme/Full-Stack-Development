using Microsoft.EntityFrameworkCore;
using PartialView.Domain.Data;
using PartialView.Domain.Entities;
using PartialView.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Repositories
{
    public class PersonDAO : IPersonDAO // : IPersonDAO invullen en dan implement interface
    {
        private readonly PersonDbContext _context;

        public PersonDAO(PersonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllPersonAsync(JobType type) {
            // => goes operator

            // Uitleg Lambda Expression
            // Expression lambda that has an expression as its body:
            //  (input-parameters) => expression

            // this  '=>' is the goes operator
            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions

            // uitleg LINQ
            // https://www.tutorialsteacher.com/linq/linq-method-syntax

            return await _context.Persons.Where(p => p.Job == type).ToListAsync(); // p is een parameter
        }
    }
}
