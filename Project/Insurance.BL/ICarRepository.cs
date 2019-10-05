using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BL.Models;

namespace Insurance.BL
{
    public interface ICarRepository
    {
        /// <summary>
        /// Метод возвращает Insurance.BL.Models.Car по id.
        /// </summary>
        /// <param name="carId">Id по которому производится возврат.</param>
        /// <returns>Insurance.BL.Models.Car.</returns>
        Car GetCar(Guid carId);

        /// <summary>
        /// Метод возвращает результат добавления нового автомобиля в систему.
        /// </summary>
        /// <param name="car">Insurance.BL.Models.Car для добавления в систему.</param>
        /// <returns>true, если автомобиль успешно добавлен, иначе - false.</returns>
        bool CarRegistration(Car car);

    }
}
