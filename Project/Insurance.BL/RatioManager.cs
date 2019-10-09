using Insurance.BL.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BL.Models;

namespace Insurance.BL
{
    /// <summary>
    /// Класс представляет методы обработки коэффициентов расчета стоимости полиса.
    /// </summary>
    public class RatioManager
    {
        private readonly IRatioRepository _ratioRepository;

        public RatioManager(IRatioRepository ratioRepository)
        {
            _ratioRepository = ratioRepository;
        }

        /// <summary>
        /// Метод возвращает коэффициенты рассчета суммы полиса по номеру автомобиля.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля для поиска.</param>
        /// <returns>Insurance.BL.Models.Ratio</returns>
        public Ratio GetRatio(string carNumber)
        {
            return _ratioRepository.GetRatio(carNumber);
        }

        public int ToCalculate(Car car, User user )
        {
            throw new NotImplementedException();

            var carAge = DateTime.Today.Year - car.ManufacturedYear;
            var drivingExperience = DateTime.Today - user.DriverLicenseDate;
            var driverAgeRatio = GetDriverAgeRatio(user.BirthDate);
            var enginePower = car.EnginePower;

        }

        private double GetCarAgeRatio(int carAge)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод возвращает возраст водителя, рассчитанный исходя из даты рождения.
        /// </summary>
        /// <param name="birthDate">Дата рождения.</param>
        /// <returns>Возраст водителя - полное кол-во лет.</returns>
        private int GetDriverAgeInYears(DateTime birthDate)
        {
            var driverAge = DateTime.Today.Year - birthDate.Year;
            if (DateTime.Now.Month < birthDate.Month
                || (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
            {
                 driverAge--;
            }

            return driverAge;
        }

        /// <summary>
        /// Метод возвращает коэффициент, рассчитанный исходя из возраста водителя.
        /// </summary>
        /// <param name="driverAge">Возраст водителя для рассчета.</param>
        /// <returns>Коэффициент:
        /// До 22, коффициент = 1.8
        /// От 22 до 26, коэффициент = 1.5
        /// От 26 до 65, коэффициент = 1
        /// От 65, коэффициент = 1.4</returns>
        private double GetDriverAgeRatio(DateTime birthDate)
        {
            var driverAge = GetDriverAgeInYears(birthDate);

            var ratio = driverAge < 22 ? 1.8
                : driverAge >= 22 && driverAge < 26 ? 1.5
                : driverAge > 65 ? 1.4
                : 1;

            return ratio;
        }
    }
}
