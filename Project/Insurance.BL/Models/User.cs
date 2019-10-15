using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BL.Models
{    
    /// <summary>
    /// Представляет класс User для BL.
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// Идентификатор роли пользователя. По умолчанию: 1 - user.
        /// </summary>
        const int UserRole = 1;

        /// <summary>
        /// Константа представляет кол-во дней (3650 ~ 10 лет)
        /// </summary>
        const int AgeInDays = 3650;

        /// <summary>
        /// Константа представляет минимальный год.
        /// </summary>
        const int MinYear = 1920;

        /// <summary>
        /// Константа представляет кол-во дней (4380 ~ 12 лет)
        /// </summary>
        const int DriverLicenseAgeInDays = 4380;

        /// <summary>
        /// E-mail клиента.
        /// </summary>
        public string EMail { get; }

        /// <summary>
        /// Полное имя клиента.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Дата рождения клиента.
        /// </summary>
        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            private set
            {
                //Исключение, если указанный возраст старше MinYear год.
                if (value < new DateTime(MinYear, 01, 01))
                {
                    throw new ArgumentOutOfRangeException("Год рождения не может быть меньше 1920!");
                }

                //Исключение если указанный возраст клиента моложе AgeInDays.
                if ((DateTime.Today - value) < new TimeSpan(AgeInDays, 0, 0, 0))
                {
                    throw new ArgumentOutOfRangeException("Слишком молодой возраст!");
                }

                _birthDate = value;
            }
        }

        /// <summary>
        /// Дата выдачи водительских прав клиента.
        /// </summary>
        private DateTime _driverLicenseDate;
        public DateTime DriverLicenseDate
        {
            get
            {
                return _driverLicenseDate;
            }
            private set
            {
                //Исключение, если указанный год выдачи прав старше MinYear год.
                if (value < new DateTime(MinYear, 01, 01))
                {
                    throw new ArgumentOutOfRangeException("Год выдачи прав не может быть меньше 1920!");
                }

                //Исключение если указанный год выдачи прав соответствует возрасту менее 12 лет.
                if ((value - BirthDate) < new TimeSpan(DriverLicenseAgeInDays, 0, 0, 0))
                {
                    throw new ArgumentOutOfRangeException("Возраст выдачи прав не может быть меньше 12 лет!");
                }

                _driverLicenseDate = value;
            }
        }

        /// <summary>
        /// Хэш-код пароля пользователя.
        /// </summary>
        public string PasswordHash { get; }

        /// <summary>
        /// Коллекция ролей пользователя.
        /// </summary>
        public List<int> Role { get; private set; }

        public User(string eMail, string name, DateTime birthDate, DateTime driverLicenseDate, string passwordHash)
        {
            EMail = eMail;
            Name = name;
            BirthDate = birthDate;
            DriverLicenseDate = driverLicenseDate;
            PasswordHash = passwordHash;

            //Установка по умолчанию роли user.
            Role = new List<int>() { UserRole };
        }

        /// <summary>
        /// Метод добавляет роль в список ролей текущего экземпляра класса.
        /// </summary>
        /// <param name="role">Роль для добавления в список.</param>
        public void AddRole(Role role)
        {
            if (!Role.Contains(role.RoleId))
                Role.Add(role.RoleId);
        }

        /// <summary>
        /// Определяет, равны ли значения этого экземпляра и указанного объекта Insurance.BL.Models.User
        /// </summary>
        /// <param name="obj">Объект для сравнения с данным экземпляром.</param>
        /// <returns>true, если значение параметра obj совпадает со значением данного экземпляра;
        /// в противном случае — false. Если значением параметра obj является null, метод возвращает false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var user = obj as User;

            return
                EMail.Equals(user.EMail)
                && Name.Equals(user.Name)
                && BirthDate.Equals(user.BirthDate)
                && DriverLicenseDate.Equals(user.DriverLicenseDate)
                && PasswordHash.Equals(user.PasswordHash);
        }

        /// <summary>
        /// Метод возвращает хэш-код объекта.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
        {
            return
                EMail.GetHashCode()
                + Name.GetHashCode()
                + BirthDate.GetHashCode()
                + DriverLicenseDate.GetHashCode()
                + PasswordHash.GetHashCode();
        }
    }
}
