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
        /// <param name="carId">Id по которому производится возврат.</param>
        /// <returns>Insurance.BL.Models.Car.</returns>
        public Car GetCar(Guid carId)
        {
            CarModel carModel;

            try
            {
                carModel = _context.Car.Find(carId);
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
                carModel.Model,
                carModel.ManufacturedYear,
                carModel.Cost,
                carModel.EnginePower,
                null
                );
        }

        /// <summary>
        /// Метод возвращает CarModel с данными полученными из Insurance.BL.Models.Car.
        /// Свойство CarModel.Policy = null.
        /// </summary>
        /// <param name="car">Insurance.BL.Models.Car по которому берутся данные.</param>
        /// <returns>CarModel с данными из Insurance.BL.Models.Car.
        /// Свойство Policy = null.
        /// Свойство PolicyId = null.</returns>
        public CarModel CarToCarModel(Car car)
        {
            if (car == null)
                return null;

            return new CarModel()
            {
                Model = car.Model,
                ManufacturedYear = car.ManufacturedYear,
                Cost = car.Cost,
                EnginePower = car.EnginePower,
                Policy = null,
                PolicyId = null
            };
        }
    }
}
