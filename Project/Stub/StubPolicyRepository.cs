using Insurance.BL;
using Insurance.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    public class StubPolicyRepository : IPolicyRepository
    {
        public ICollection<Policy> GetPolicy(string email)
        {
            var carVesta = new Car("777TEST163RU", "Vesta", 2018, 750000, 104);
            var ratioVesta = new Ratio(1.2, 1.1, 0.8, 1.0);

            var carFord = new Car("42FORD4163RU", "Ford", 2016, 860000, 120);
            var ratioFord = new Ratio(1.6, 1.4, 0.5, 0.9);

            return new List<Policy>() {
                new Policy(5000, "test@mail.ru", DateTime.Today, carVesta, ratioVesta), 
                new Policy(4500, "test@mail.ru", new DateTime(2019, 10, 20), carFord, ratioFord),
            };
        }

        public bool PolicyRegistration(Policy policy)
        {
            return true;
        }
    }
}
