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
        /// Метод возвращает результат добавления нового автомобиля в систему.
        /// </summary>
        /// <param name="car">Insurance.BL.Models.Car для добавления в систему.</param>
        /// <returns>true, если автомобиль успешно добавлен, иначе - false.</returns>
        public bool CarRegistration(Car car)
        {
            try
            {
                var policy = _context.Policy.Find(car.PolicyId);
                var carModel = CarToCarModel(car);
                carModel.Policy = policy;
                _context.Car.Add(carModel);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
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
        /// <returns>Insurance.BL.Models.Car с данными из CarModel.</returns>
        public Car CarModelToCar(CarModel carModel)
        {
            if (carModel == null)
                return null;

            return new Car(
                carModel.CarId,
                carModel.Model,
                carModel.ManufacturedYear,
                carModel.Cost,
                carModel.EnginePower,
                carModel.Policy.PolicyID
                );
        }

        /// <summary>
        /// Метод возвращает CarModel с данными полученными из Insurance.BL.Models.Car.
        /// </summary>
        /// <param name="car">Insurance.BL.Models.Car по которому берутся данные.</param>
        /// <returns>CarModel с данными из Insurance.BL.Models.Car.</returns>
        public CarModel CarToCarModel(Car car)
        {
            if (car == null)
                return null;

            PolicyModel policy;

            try
            {
                policy = _context.Policy.Find(car.PolicyId);
            }
            catch
            {
                return null;
            }

            if (policy == null)
                return null;

            return new CarModel()
            {
                CarId = car.CarId,
                Model = car.Model,
                ManufacturedYear = car.ManufacturedYear,
                Cost = car.Cost,
                EnginePower = car.EnginePower,
                Policy = policy
            };
        }
    }
}
