using Insurance.BL.Models;

namespace Insurance.BL
{
    /// <summary>
    /// Интерфейс представляет методы управления классом автомобиля.
    /// </summary>
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
