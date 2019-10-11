using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MainRepository;
using Insurance.BL;
using MainRepository.ModelsRepository;
using Insurance.BL.Models;

namespace Insurance.WCF
{
    public class PolicyService : IPolicyService
    {
        private readonly DataContext _context = new DataContext();
        private readonly PolicyRepository _policyRepository;
        private readonly RatioRepository _ratioRepository;
        private readonly CarRepository _carRepository;
        private readonly AuthRepository _authRepository; 
        private readonly string _email;

        public PolicyService(string email)
        {
            _policyRepository = new PolicyRepository(_context);
            _ratioRepository = new RatioRepository(_context);
            _carRepository = new CarRepository(_context);
            _authRepository = new AuthRepository(_context);
            _email = email;

        }

        /// <summary>
        /// Метод возвращает итоговую стоимость полиса, рассчитанную исходя из входных данных.
        /// </summary>
        /// <param name="carCost">Стоимость автомобиля.</param>
        /// <param name="manufacturedYear">Год выпуска автомобиля.</param>
        /// <param name="driverLicenseDate">Дата выдачи прав вождения.</param>
        /// <param name="birthDate">Дата рождения водителя.</param>
        /// <param name="enginePower">Мощность двигателя автомобиля.</param>
        /// <returns>Итоговая стоимость полиса.</returns>
        public int PolicyCalculate(int carCost, int manufacturedYear, DateTime driverLicenseDate, DateTime birthDate, int enginePower)
        {
            var ratioManager = new RatioManager(_ratioRepository);
            var accountManager = new AccountManager(_authRepository);
            var user = _authRepository.GetUser(_email);
 
            var policyCost = ratioManager.CostCalculate(carCost, manufacturedYear, user.DriverLicenseDate, user.BirthDate, enginePower);

            return policyCost;
        }

        /// <summary>
        /// Метод возвращает результат регистрации полиса в системе.
        /// </summary>
        /// <param name="carCost">Стоимость автомобиля.</param>
        /// <param name="carNumber">Номер автомобиля.</param>
        /// <param name="carModel">Модель автомобиля.</param>
        /// <param name="manufacturedYear">Год выпуска автомобиля.</param>
        /// <param name="cost">Стоимость автомобиля.</param>
        /// <param name="enginePower">Мощность двигателя автомобиля.</param>
        /// <returns>true, если полис успешно зарегистрирован, иначе - false.</returns>
        public bool PolicyRegistration(int carCost, string carNumber, string carModel, int manufacturedYear, int cost, int enginePower)
        {
            var accountManager = new AccountManager(_authRepository);
            var carManager = new CarManager(_carRepository);
            var ratioManager = new RatioManager(_ratioRepository);

            var car = new Car(carNumber, carModel, manufacturedYear, cost, enginePower, null);
            var user = _authRepository.GetUser(_email);
            var ratio = ratioManager.GetRatio(car, user);
            var policyCost = ratioManager.CostCalculate(carCost, manufacturedYear, user.DriverLicenseDate, user.BirthDate, enginePower);

            var policy = new Policy(policyCost, _email, DateTime.Today, car, ratio);

            car.Policy = policy;

            return _policyRepository.PolicyRegistration(policy);
        }
    }
}
