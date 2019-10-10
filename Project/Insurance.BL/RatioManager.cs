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
            //Рассчет коэффициента, основанного на возрасте автомобиля.
            var carAgeRatio = GetCarAgeRatio(car.ManufacturedYear);

            //Рассчет коэффициента, основанного на опыте вождения водителя.
            var drivingExperience = GetDrivingExperienceRatio(user.DriverLicenseDate);

            //Рассчет коэффициента, основанного на возрасте водителя.
            var driverAgeRatio = GetDriverAgeRatio(user.BirthDate);

            //Рассчет коэффициента, основанного на мощности двигателя автомобиля.
            var enginePower = GetEnginePowerRatio(car.EnginePower);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод возвращает коэффициент, рассчитанный исходя из возраста автомобиля.
        /// </summary>
        /// <param name="manufacturedYear">Год производства автомобиля (полных лет)</param>
        /// <returns>Коэффициент:
        /// 0, коэффициент = 1.0
        /// от 1 до 3, коэффициент = 1.1
        /// от 4 до 5, коэффициент = 1.3
        /// от 6 до 7, коэффициент = 1.6
        /// от 8, коэффициент = 2.0
        /// </returns>
        private double GetCarAgeRatio(int manufacturedYear)
        {
            var carAge = DateTime.Today.Year - manufacturedYear;

            var carAgeRatio = carAge == 0 ? 1.0
                : carAge > 0 && carAge <= 3 ? 1.1
                : carAge > 3 && carAge <= 5 ? 1.3
                : carAge > 5 && carAge <= 7 ? 1.6
                : 2.0;

            return carAgeRatio;
        }

        /// <summary>
        /// Метод возвращает коэффициент, рассчитанный исходя из опыта вождения автомобиля.
        /// </summary>
        /// <param name="driverLicenseDate">Дата получения прав водителя.</param>
        /// <returns>Коэффициент:
        /// До 2, коэффициент = 1.8
        /// От 3 до 5, коэффициент = 1.5
        /// От 6 до 10 коэффициент = 1
        /// Свыше 10, коэффициент = 0.8</returns>
        private double GetDrivingExperienceRatio(DateTime driverLicenseDate)
        {
            var drivingExpInYear = GetPeriodInYears(driverLicenseDate);

            var ratio = drivingExpInYear < 3 ? 1.8
                : drivingExpInYear >= 3 && drivingExpInYear <= 5 ? 1.2
                : drivingExpInYear >= 6 && drivingExpInYear <= 10 ? 1
                : 0.8;

            return ratio;
        }

        /// <summary>
        /// Метод возвращает коэффициент, рассчитанный исходя из возраста водителя.
        /// </summary>
        /// <param name="birthDate">Дата рождения водителя.</param>
        /// <returns>Коэффициент:
        /// До 22, коффициент = 1.8
        /// От 23 до 30, коэффициент = 1.5
        /// От 31 до 64, коэффициент = 1
        /// От 65, коэффициент = 1.4</returns>
        private double GetDriverAgeRatio(DateTime birthDate)
        {
            var driverAge = GetPeriodInYears(birthDate);

            var ratio = driverAge <= 22 ? 1.8
                : driverAge >= 23 && driverAge <= 30 ? 1.5
                : driverAge >= 31 && driverAge <= 64 ? 1
                : 1.4;

            return ratio;
        }

        /// <summary>
        /// Метод возвращает коэффициент, рассчитанный исходя из мощности двигателя автомобиля.
        /// </summary>
        /// <param name="enginePower">Мощность двигателя автомобиля (в лошадиных силах).</param>
        /// <returns>Коэффициент:
        /// До 50, коэффициент = 0.6
        /// От 51 до 80, коэффициент = 0.9
        /// От 81 до 110, коэффициент = 1.2
        /// От 111 до 150, коэффициент = 1.4
        /// Свыше 150, коэффициент = 1.6</returns>
        private double GetEnginePowerRatio(int enginePower)
        {
            var ratio = enginePower <= 50 ? 0.6
                : enginePower >= 51 && enginePower <= 80 ? 0.9
                : enginePower >= 81 && enginePower <= 110 ? 1.2
                : enginePower >= 111 && enginePower <= 150 ? 1.4
                : 1.6;

            return ratio;
        }

        /// <summary>
        /// Метод возвращает кол-во полных лет, прошедших со указанной даты до текущей даты.
        /// </summary>
        /// <param name="sourceDate">Дата с которой начинается отсчет лет до текущей даты.</param>
        /// <returns>Полное кол-во лет, прошедшее с указанной даты до текущей даты.</returns>
        private int GetPeriodInYears(DateTime sourceDate)
        {
            var period = DateTime.Today.Year - sourceDate.Year;
            if (DateTime.Now.Month < sourceDate.Month
                || (DateTime.Now.Month == sourceDate.Month && DateTime.Now.Day < sourceDate.Day))
            {
                period--;
            }

            return period;
        }
    }
}
