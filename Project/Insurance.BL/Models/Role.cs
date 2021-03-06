﻿using System.Runtime.Serialization;

namespace Insurance.BL.Models
{
    /// <summary>
    /// Класс представляет объект Role.
    /// </summary>
    [DataContract]
    public class Role
    {
        /// <summary>
        /// Поле представляет экземпляр Role типа user.
        /// </summary>
        public static readonly Role User = new Role("user");

        /// <summary>
        /// Поле представляет экземпляр Role типа administrator.
        /// </summary>
        public static readonly Role Administrator = new Role("administrator");

        /// <summary>
        /// Наименование роли.
        /// </summary>
        [DataMember]
        public string RoleName { get; private set; }

        public Role(string roleName)
        {
            RoleName = roleName.ToLower();
        }

        /// <summary>
        /// Определяет, равны ли значения этого экземпляра и указанного объекта Insurance.BL.Models.Role
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

            var role = obj as Role;

            return RoleName.Equals(role.RoleName);
        }

        /// <summary>
        /// Метод возвращает хэш-код объекта.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
        {
            return RoleName.GetHashCode();
        }
    }
}
