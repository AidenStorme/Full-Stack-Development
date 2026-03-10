using Beer9.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Beer9.Controllers
{
    public class GenericController : Controller
    {
        public void Index()
        {
            //DataStore countries = new DataStore();

            //countries.AddOrUpdate(0, "Belgium");
            //countries.AddOrUpdate(1, "US");
            //countries.AddOrUpdate(2, "France");

            //Debug.WriteLine(countries.GetData(2));

            DataStore<string> cities = new DataStore<string>(); // Hier geef je dus mee welk type je DataStore wordt

            cities.AddOrUpdate(0, "Mumbai");
            cities.AddOrUpdate(1, "New York");
            cities.AddOrUpdate(2, "London");

            DataStore<int> empIds = new DataStore<int>();
            empIds.AddOrUpdate(0, 56);
            empIds.AddOrUpdate(1, 73);
            empIds.AddOrUpdate(2, 11);
        }
    }
}
