using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BL.Models;

namespace Insurance.BL
{
    /// <summary>
    /// Класс представляет методы управления типа Car.
    /// </summary>
    public class CarManager
    {
        /// <summary>
        /// Экземпляр класса, реализующего интерфейс ICarRepository.
        /// </summary>
        private readonly ICarRepository _carRepository;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="carRepository">Репозиторий, реализующий интерфейс ICarRepository.</param>
        public CarManager(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        /// <summary>
        /// Метод возвращает Insurance.BL.Models.Car по номеру автомобиля.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля по которому производится возврат.</param>
        /// <returns>Insurance.BL.Models.Car.</returns>
        public Car GetCar(string carNumber)
        {
            var carNumberUpperLetters = carNumber.ToUpper();
            return carNumberUpperLetters.IsCarNumberCorrect() ? _carRepository.GetCar(carNumberUpperLetters) : null;
        }
    }
}
