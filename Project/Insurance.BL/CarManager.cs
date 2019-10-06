using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BL.Models;

namespace Insurance.BL
{
    public class CarManager
    {
        private readonly ICarRepository _carRepository;

        public CarManager(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        /// <summary>
        /// Метод возвращает Insurance.BL.Models.Car по id.
        /// </summary>
        /// <param name="carId">Id по которому производится возврат.</param>
        /// <returns>Insurance.BL.Models.Car.</returns>
        public Car GetCar(Guid carId)
        {
            return _carRepository.GetCar(carId);
        }
    }
}
