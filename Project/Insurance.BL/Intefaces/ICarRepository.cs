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
        /// <param name="carNumber">Id по которому производится возврат.</param>
        /// <returns>Insurance.BL.Models.Car.</returns>
        Car GetCar(string carNumber);
    }
}
