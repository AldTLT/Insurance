using Insurance.BL;
using Insurance.BL.Models;
using System;
using System.Collections.Generic;

namespace Stub
{
    /// <summary>
    /// Заглушка для тестирования и настройки фронтенда.
    /// </summary>
    public class StubPolicyRepository : IPolicyRepository
    {
        /// <summary>
        /// Метод возвращает экземпляр класса Policy в зависимости от номера автомобиля.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля.</param>
        /// <returns>Экземпляр класса Policy.</returns>
        public Policy GetPolicy(string carNumber)
        {
            Policy policy;

            if (carNumber.Equals("777TEST163RU"))
            {
                var carVesta = new Car("777TEST163RU", "Vesta", 2018, 750000, 104);
                var ratioVesta = new Ratio(1.2, 1.1, 0.8, 1.0);
                policy = new Policy(5000, "vr0rtex@mail.ru", DateTime.Today, carVesta, ratioVesta);
                policy.PolicyId = new Guid("12345678-1234-5678-9012-123456789012");
            }
            else
            {
                var carFord = new Car("42FORD4163RU", "Ford", 2016, 860000, 120);
                var ratioFord = new Ratio(1.6, 1.4, 0.5, 0.9);
                policy = new Policy(4500, "vr0rtex@mail.ru", new DateTime(2019, 12, 20), carFord, ratioFord);
                policy.PolicyId = new Guid("09876543-1234-2341-4567-678787879876");
            }

            return policy;
        }

        /// <summary>
        /// Метод возвращает коллекцию экземпляров класса Policy по email пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя.</param>
        /// <returns>Коллекция экземпляров класса Policy.</returns>
        public ICollection<Policy> GetPolicys(string email)
        {
            var carVesta = new Car("777TEST163RU", "Vesta", 2018, 750000, 104);
            var ratioVesta = new Ratio(1.2, 1.1, 0.8, 1.0);

            var carFord = new Car("42FORD4163RU", "Ford", 2016, 860000, 120);
            var ratioFord = new Ratio(1.6, 1.4, 0.5, 0.9);

            var policy1 = new Policy(5000, "vr0rtex@mail.ru", DateTime.Today, carVesta, ratioVesta);
            policy1.PolicyId = new Guid("12345678-1234-5678-9012-123456789012");

            var policy2 = new Policy(4500, "vr0rtex@mail.ru", new DateTime(2019, 12, 20), carFord, ratioFord);
            policy2.PolicyId = new Guid("09876543-1234-2341-4567-678787879876");

            return new List<Policy>() {
                policy1, 
                policy2
            };
        }

        /// <summary>
        /// Метод возвращает результат регистрации полиса.
        /// </summary>
        /// <param name="policy">Полис для регистрации в системе.</param>
        /// <returns>true</returns>
        public bool PolicyRegistration(Policy policy)
        {
            return true;
        }
    }
}
