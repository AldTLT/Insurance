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
using Stub;
using Insurance.BL.Intefaces;

namespace Insurance.WCF
{
    /// <summary>
    /// Класс представляет сервис управления полисом.
    /// </summary>
    public class PolicyService : IPolicyService
    {
        private readonly DataContext _context = new DataContext();
        private readonly IPolicyRepository _policyRepository;
        private readonly IRatioRepository _ratioRepository;
        private readonly ICarRepository _carRepository;
        private readonly IAuthRepository _authRepository; 

        public PolicyService()
        {
            //_policyRepository = new PolicyRepository(_context);
            //_ratioRepository = new RatioRepository(_context);
            //_carRepository = new CarRepository(_context);
            //_authRepository = new AuthRepository(_context);

            _policyRepository = new StubPolicyRepository();
            _authRepository = new StubAuthRepository();
            _ratioRepository = new StubRatioRepository();
            _carRepository = new StubCarRepository();
        }

        /// <summary>
        /// Метод возвращает коллекцию Policy по email пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя.</param>
        /// <returns>ICollection<Policy> принадлежащих пользователяю.</returns>
        public ICollection<Policy> GetPolicy(string email)
        {
            return _policyRepository.GetPolicy(email);
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
        public int PolicyCalculate(string email, int carCost, int manufacturedYear, DateTime driverLicenseDate, DateTime birthDate, int enginePower)
        {
            var ratioManager = new RatioManager(_ratioRepository);
            var accountManager = new AccountManager(_authRepository);
            var user = _authRepository.GetUser(email);
 
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
        public bool PolicyRegistration(string email, int carCost, string carNumber, string carModel, int manufacturedYear, int enginePower)
        {
            var accountManager = new AccountManager(_authRepository);
            var carManager = new CarManager(_carRepository);
            var ratioManager = new RatioManager(_ratioRepository);

            var car = new Car(carNumber, carModel, manufacturedYear, carCost, enginePower);
            var user = _authRepository.GetUser(email);
            var ratio = ratioManager.GetRatio(car, user);
            var policyCost = ratioManager.CostCalculate(carCost, manufacturedYear, user.DriverLicenseDate, user.BirthDate, enginePower);

            var policy = new Policy(policyCost, email, DateTime.Today, car, ratio);

            return _policyRepository.PolicyRegistration(policy);
        }
    }
}
