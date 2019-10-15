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
        /// Поле представляет экземпляр RoleModel типа user.
        /// </summary>
        public static readonly RoleModel User = new RoleModel() { RoleId = 1, RoleName = "user" };

        /// <summary>
        /// Поле представляет экземпляр RoleModel типа administrator.
        /// </summary>
        public static readonly RoleModel Administrator = new RoleModel() { RoleId = 2, RoleName = "administrator" };

        /// <summary>
        /// Уникальный идентификатор роли.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Наименование роли.
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Коллекция клиентов, соответствующих роли.
        /// </summary>
        public virtual ICollection<ClientModel> Client { get; set; }

        public RoleModel()
        {
            Client = new HashSet<ClientModel>();
        }

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
