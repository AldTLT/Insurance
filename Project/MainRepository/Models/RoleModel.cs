using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace MainRepository.Models
{
    /// <summary>
    /// Класс entity роль.
    /// </summary>
    public class RoleModel
    {
        /// <summary>
        /// Поле представляет экземпляр RoleModel типа user.
        /// </summary>
        public static readonly RoleModel User = new RoleModel() { RoleName = "user" };

        /// <summary>
        /// Поле представляет экземпляр RoleModel типа administrator.
        /// </summary>
        public static readonly RoleModel Administrator = new RoleModel() { RoleName = "administrator" };

        /// <summary>
        /// Наименование роли.
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Коллекция клиентов, соответствующих роли.
        /// </summary>
        public virtual ICollection<ClientModel> Clients { get; set; }

        /// <summary>
        /// Конструктор класса Role.
        /// </summary>
        public RoleModel()
        {
            Clients = new HashSet<ClientModel>();
        }

        /// <summary>
        /// Класс представляет метод конфигурирования RolesModel.
        /// </summary>
        public class RoleConfiguration : EntityTypeConfiguration<RoleModel>
        {
            public RoleConfiguration()
            {
                this.ToTable("Role")
                    .HasKey(r => r.RoleName);
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

            return RoleName.Equals(roleModel.RoleName);
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
