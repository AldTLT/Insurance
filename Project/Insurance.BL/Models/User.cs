﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;

namespace Insurance.BL.Models
{
    /// <summary>
    /// Класс представляет объект User.
    /// </summary>
    [DataContract]
    public class User
    {
        /// <summary>
        /// Идентификатор роли пользователя. По умолчанию: user.
        /// </summary>
        const string UserRole = "user";

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
        [DataMember]
        public string EMail { get; private set; }

        /// <summary>
        /// Полное имя клиента.
        /// </summary>
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Дата рождения клиента.
        /// </summary>
        private DateTime _birthDate;

        [DataMember]
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

        [DataMember]
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
        [DataMember]
        public string PasswordHash { get; private set; }

        /// <summary>
        /// Коллекция ролей пользователя.
        /// </summary>
        [DataMember]
        public List<string> Role { get; private set; }

        public User(string eMail, string name, DateTime birthDate, DateTime driverLicenseDate, string passwordHash)
        {
            EMail = eMail.ToLower();
            Name = ToUpperFirstLetter(name);
            BirthDate = birthDate;
            DriverLicenseDate = driverLicenseDate;
            PasswordHash = passwordHash;

            //Установка по умолчанию роли user.
            Role = new List<string>() { UserRole };
        }

        /// <summary>
        /// Метод добавляет роль в список ролей текущего экземпляра класса.
        /// </summary>
        /// <param name="role">Роль для добавления в список.</param>
        public void AddRole(Role role)
        {
            if (!Role.Contains(role.RoleName.ToLower()))
                Role.Add(role.RoleName.ToLower());
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

        /// <summary>
        /// Метод форматирует полное имя пользователя: имя с заглавной буквы (Иванов Иван Иванович).
        /// </summary>
        /// <param name="userFullName">Полное имя пользователя.</param>
        /// <returns>Форматированное имя пользователя.</returns>
        private string ToUpperFirstLetter(string userFullName)
        {
            var nameArray = userFullName.Split(' ');
            var upperFirstLetterName = new StringBuilder();

            foreach (var name in nameArray)
            {
                var firstLetter = Char.ToUpper(name[0]);
                var formattedName = firstLetter + name.ToLower().Substring(1, name.Length - 1);

                upperFirstLetterName.Append(formattedName + " ");
            }

            //Удаление последнего пробела.
            upperFirstLetterName.Remove(upperFirstLetterName.Length - 1, 1);

            return upperFirstLetterName.ToString();
        }
    }
}
