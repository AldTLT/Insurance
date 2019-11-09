using Insurance.BL;
using Insurance.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    /// <summary>
    /// Заглушка для тестирования и настройки фронтенда.
    /// </summary>
    public class StubPolicyRepository : IPolicyRepository
    {
        public ICollection<Policy> GetPolicy(string email)
        {
            var carVesta = new Car("777TEST163RU", "Vesta", 2018, 750000, 104);
            var ratioVesta = new Ratio(1.2, 1.1, 0.8, 1.0);

            var carFord = new Car("42FORD4163RU", "Ford", 2016, 860000, 120);
            var ratioFord = new Ratio(1.6, 1.4, 0.5, 0.9);

            var policy1 = new Policy(5000, "test@mail.ru", DateTime.Today, carVesta, ratioVesta);
            policy1.PolicyId = new Guid("12345678-1234-5678-9012-123456789012");

            var policy2 = new Policy(4500, "test@mail.ru", new DateTime(2019, 12, 20), carFord, ratioFord);
            policy2.PolicyId = new Guid("09876543-1234-2341-4567-678787879876");

            return new List<Policy>() {
                policy1, 
                policy2
            };
        }

        public bool PolicyRegistration(Policy policy)
        {
            return true;
        }
    }
}
