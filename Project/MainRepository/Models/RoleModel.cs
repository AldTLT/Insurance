using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainRepository.Models
{
    public class RoleModel
    {
        /// <summary>
        /// Уникальный идентификатор роли.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Наименование роли.
        /// </summary>
        public string RoleName { get; set; }

        public class RoleConfiguration : EntityTypeConfiguration<RoleModel>
        {
            public RoleConfiguration()
            {
                this.ToTable("Role")
                    .HasKey(r => r.RoleId);
                this.Property(r => r.RoleId)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                this.Property(r => r.RoleName)
                    .HasMaxLength(30);                
            }
        }

        /// <summary>
        /// Определяет, равны ли значения этого экземпляра и указанного объекта MainRepository.Models.RoleModel.
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

            var roleModel = obj as RoleModel;

            return
                RoleId.Equals(roleModel.RoleId)
                && RoleName.Equals(roleModel.RoleName);
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
