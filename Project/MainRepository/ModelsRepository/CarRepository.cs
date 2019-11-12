using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BL;
using Insurance.BL.Models;
using MainRepository.Models;

namespace MainRepository.ModelsRepository
{
    /// <summary>
    /// Класс представляет методы управления CarModel.
    /// </summary>
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод возвращает Insurance.BL.Models.Car по id.
        /// </summary>
        /// <param name="carNumber">Id по которому производится возврат.</param>
        /// <returns>Insurance.BL.Models.Car.</returns>
        public Car GetCar(string carNumber)
        {
            CarModel carModel;

            try
            {
                carModel = _context.Car.Find(carNumber);
            }
            catch
            {
                return null;
            }

            return CarModelToCar(carModel);
        }

        /// <summary>
        /// Метод возвращает Insurance.BL.Models.Car с данными полученными из CarModel.
        /// </summary>
        /// <param name="carModel">CarModel по которому берутся данные.</param>
        /// <returns>Insurance.BL.Models.Car с данными из CarModel.
        /// Свойство Policy = null.</returns>
        public Car CarModelToCar(CarModel carModel)
        {
            if (carModel == null)
                return null;

            return new Car(
                carModel.CarNumber,
                carModel.Model,
                carModel.ManufacturedYear,
                carModel.CarCost,
                carModel.EnginePower
                );
        }

        /// <summary>
        /// Метод возвращает CarModel с данными полученными из Insurance.BL.Models.Car.
        /// Свойство CarModel.Policy = null.
        /// </summary>
        /// <param name="car">Insurance.BL.Models.Car по которому берутся данные.</param>
        /// <returns>CarModel с данными из Insurance.BL.Models.Car.
        /// Свойство Policy = null.</returns>
        public CarModel CarToCarModel(Car car)
        {
            if (car == null)
                return null;

            return new CarModel()
            {
                CarNumber = car.CarNumber,
                Model = car.Model,
                ManufacturedYear = car.ManufacturedYear,
                CarCost = car.Cost,
                EnginePower = car.EnginePower,
                Policy = null
            };
        }
    }
}
