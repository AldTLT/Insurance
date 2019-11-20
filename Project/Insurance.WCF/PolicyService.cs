using System;
using System.Collections.Generic;
using MainRepository;
using Insurance.BL;
using MainRepository.ModelsRepository;
using Insurance.BL.Models;
using Insurance.BL.Intefaces;
using Stub;

namespace Insurance.WCF
{
    /// <summary>
    /// Класс представляет сервис управления полисом.
    /// </summary>
    public class PolicyService : IPolicyService
    {
        /// <summary>
        /// Контекст соединения БД.
        /// </summary>
        private readonly DataContext _context = new DataContext();

        /// <summary>
        /// Экземпляр репозитория управления полисом.
        /// </summary>
        private readonly IPolicyRepository _policyRepository;

        /// <summary>
        /// Экземпляр репозитория управления коэффициентами.
        /// </summary>
        private readonly IRatioRepository _ratioRepository;

        /// <summary>
        /// Экземпляр репозитория управления автомобилем.
        /// </summary>
        private readonly ICarRepository _carRepository;

        /// <summary>
        /// Экземпляр репозитория управления аккаунтом.
        /// </summary>
        private readonly IAuthRepository _authRepository; 

        public PolicyService()
        {
            _policyRepository = new PolicyRepository(_context);
            _ratioRepository = new RatioRepository(_context);
            _carRepository = new CarRepository(_context);
            _authRepository = new AuthRepository(_context);
        }

        /// <summary>
        /// Метод возвращает коллекцию Policy по email пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя.</param>
        /// <returns>ICollection<Policy> принадлежащих пользователяю.</returns>
        public ICollection<Policy> GetPolicy(string email)
        {
            return _policyRepository.GetPolicys(email);
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
        /// <returns>Номер полиса, если полис успешно зарегистрирован, иначе - null.</returns>
        public string PolicyRegistration(string email, int carCost, string carNumber, string carModel, int manufacturedYear, int enginePower)
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
