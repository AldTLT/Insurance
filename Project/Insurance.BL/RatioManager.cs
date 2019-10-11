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
        /// <summary>
        /// Константа базовая ставка, составляет 5% от стоимости автомобиля.
        /// </summary>
        const double baseRate = 0.05;

        private readonly IRatioRepository _ratioRepository;

        public RatioManager(IRatioRepository ratioRepository)
        {
            _ratioRepository = ratioRepository;
        }

        /// <summary>
        /// Метод возвращает стоимость полиса, рассчитанную с учетом коэффициентов от базовой стоимости.
        /// </summary>
        /// <param name="carCost">Базовая стоимость полиса.</param>
        /// <returns>Итоговая стоимость полиса.</returns>
        public int CostCalculate(int carCost, int manufacturedYear, DateTime driverLicenseDate, DateTime birthDate, int enginePower)
        {
            var coefficients = CalculateRatio(manufacturedYear, driverLicenseDate, birthDate, enginePower);
            var baseCost = carCost * baseRate;

            return (int)Math.Truncate(baseCost * coefficients.Item1 * coefficients.Item2 * coefficients.Item3 * coefficients.Item4);
        }

        /// <summary>
        /// Метод возвращает Ratio по номеру автомобиля.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля для поиска.</param>
        /// <returns>Insurance.BL.Models.Ratio</returns>
        public Ratio GetRatio(string carNumber)
        {
            return _ratioRepository.GetRatio(carNumber);
        }

        /// <summary>
        /// Метод возвращает Ratio с коэффициентами рассчета суммы полиса.
        /// </summary>
        /// <param name="car">Экземпляр класса Insurance.BL.Models.Car</param>
        /// <param name="user">Экземпляр класса Insurance.BL.Models.User</param>
        /// <returns>Insurance.BL.Models.Ratio</returns>
        public Ratio GetRatio(Car car, User user)
        {
            var coefficients = CalculateRatio(car.ManufacturedYear, user.DriverLicenseDate, user.BirthDate, car.EnginePower);
            var ratio = new Ratio(coefficients.Item1, coefficients.Item2, coefficients.Item3, coefficients.Item4);

            return ratio;
        }

        /// <summary>
        /// Метод возвращает Tuple<double, double, double, double> с коэффициентами.
        /// </summary>
        /// <param name="manufacturedYear">Год выпуска автомобиля.</param>
        /// <param name="driverLicenseDate">Дата выдачи прав вождения.</param>
        /// <param name="birthDate">Дата рождения водителя.</param>
        /// <param name="enginePower">Мощность двигателя автомобиля.</param>
        /// <returns>Tuple<double, double, double, double> с коэффициентами.
        /// Item1 - Год выпуска автомобиля.
        /// Item2 - Дата выдачи прав вождения.
        /// Item3 - Дата рождения водителя.
        /// Item4 - Мощность двигателя автомобиля.</returns>
        private Tuple<double, double, double, double> CalculateRatio(int manufacturedYear, DateTime driverLicenseDate, DateTime birthDate, int enginePower)
        {
            //Рассчет коэффициента, основанного на возрасте автомобиля.
            var carAgeRatio = GetCarAgeRatio(manufacturedYear);

            //Рассчет коэффициента, основанного на опыте вождения водителя.
            var drivingExpRatio = GetDrivingExperienceRatio(driverLicenseDate);

            //Рассчет коэффициента, основанного на возрасте водителя.
            var driverAgeRatio = GetDriverAgeRatio(birthDate);

            //Рассчет коэффициента, основанного на мощности двигателя автомобиля.
            var enginePowerRatio = GetEnginePowerRatio(enginePower);

            return new Tuple<double, double, double, double>(carAgeRatio, drivingExpRatio, driverAgeRatio, enginePowerRatio);
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
