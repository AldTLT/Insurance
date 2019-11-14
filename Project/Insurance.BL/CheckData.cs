using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Insurance.BL
{
    /// <summary>
    /// Класс представляет методы проверки вводимых данных.
    /// </summary>
    public static class CheckData
    {
        /// <summary>
        /// Константа представляет кол-во дней (3650 ~ 10 лет)
        /// </summary>
        const int AgeInDays = 3650;

        /// <summary>
        /// Константа представляет минимальный год.
        /// </summary>
        const int MinYear = 1920;

        /// <summary>
        /// Метод возвращает результат проверки E-mail на корректность.
        /// </summary>
        /// <param name="mail">E-mail для проверки.</param>
        /// <returns>true, если e-mail в правильном формате, иначе - false.</returns>
        public static bool IsEmailCorrect(this string email)
        {
            return new EmailAddressAttribute().IsValid(email.ToLower());
        }

        /// <summary>
        /// Метод возвращает результат проверки роли пользователя на корректность.
        /// </summary>
        /// <param name="role">Роль пользователя.</param>
        /// <returns>true, если роль есть в списке ролей, иначе - false.</returns>
        public static bool IsRoleCorrect(this string role)
        {
            return role.ToLower().Equals(RoleList.user.ToString()) 
                || role.ToLower().Equals(RoleList.administrator.ToString()) 
                ? true : false;
        }

        /// <summary>
        /// Метод возвращает результат проверки номера автомобиля на корректность.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля для проверки.</param>
        /// <returns>true, если номер состоит только из букв латинского алфавита и цифр,
        /// а так же длинной от 3 до 15 символов, иначе - false</returns>
        public static bool IsCarNumberCorrect(this string carNumber)
        {
            var regex = new Regex(@"(^[A-Za-z0-9]{3,15})+$");
            return regex.IsMatch(carNumber);
        }

        /// <summary>
        /// Метод возвращает результат проверки даты рождения пользователя на корректность.
        /// </summary>
        /// <param name="birthDate">Дата рождения.</param>
        /// <returns>true если год рождения больше 1920 года, 
        /// ,если пользователю 10 лет или старше, 
        /// если дата рождения не null, иначе - false</returns>
        public static bool IsBirthDateCorrect(this DateTime birthDate)
        {
            return birthDate == null
                || birthDate < new DateTime(MinYear, 01, 01)
                || (DateTime.Today - birthDate) < new TimeSpan(AgeInDays, 0, 0, 0) ? false : true;
        }

        /// <summary>
        /// Метод возвращает результат проверки даты выдачи прав пользователя на корректность.
        /// </summary>
        /// <param name="driverLicenseDate">Дата выдачи прав.</param>
        /// <returns>true если дата выдачи прав больше 1920 года,
        /// если дата не больше чем сегодняшняя дата, если дата не равна null,
        /// иначе - false.</returns>
        public static bool IsDriverLicenseDateCorrect(this DateTime driverLicenseDate)
        {
            return driverLicenseDate == null
                || driverLicenseDate < new DateTime(MinYear, 01, 01)
                || (driverLicenseDate > DateTime.Today) ? false : true;
        }

        /// <summary>
        /// Метод возвращает результат проверки года выпуска автомобиля на корректность.
        /// </summary>
        /// <param name="manufacturedYear">Год выпуска автомобиля.</param>
        /// <returns>true, если год находится между 1920 и текущим годом, иначе - false.</returns>
        public static bool IsManufacturedYearCorrect(this int manufacturedYear)
        {
            var yearToday = DateTime.Today.Year;
            return manufacturedYear < 1920 || manufacturedYear > yearToday ? false : true;
        }

        /// <summary>
        /// Метод возвращает результат проверки мощности двигателя автомобиля на корректность.
        /// </summary>
        /// <param name="enginePower">Мощность двигателя (л.с.)</param>
        /// <returns>true, если мощность двигателя в диапазоне от 2 до 300 л.с., иначе - false.</returns>
        public static bool IsEnginePowerCorrect(this int enginePower)
        {
            return enginePower < 2 || enginePower > 300 ? false : true;
        }

        /// <summary>
        /// Метод возвращает результат проверки стоимости автомобиля на корректность.
        /// </summary>
        /// <param name="carCost">Стоимость автомобиля.</param>
        /// <returns>true, если стоимость между 5.000 и 20.000.000, иначе - false.</returns>
        public static bool IsCarCostCorrect(this int carCost)
        {
            return carCost < 5000 || carCost > 20000000 ? false : true; 
        }
    }
}
