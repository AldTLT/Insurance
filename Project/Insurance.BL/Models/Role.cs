using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BL.Models
{
    public class Role
    {
        /// <summary>
        /// Уникальный идентификатор роли.
        /// </summary>
        public int RoleId { get; }

        /// <summary>
        /// Наименование роли.
        /// </summary>
        public string RoleName { get; }

        public Role(int roleId, string roleName)
        {
            RoleId = roleId;
            RoleName = roleName;
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

            return
                RoleId.Equals(role.RoleId)
                && RoleName.Equals(role.RoleName);
        }

        /// <summary>
        /// Метод возвращает хэш-код объекта.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
        {
            return
                RoleId.GetHashCode()
                + RoleName.GetHashCode();
        }
    }
}
