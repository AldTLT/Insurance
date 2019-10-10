using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainRepository.Models
{
    /// <summary>
    /// Класс представляет сущность клиента.
    /// </summary>
    public class ClientModel
    {
        /// <summary>
        /// E-mail клиента.
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// Полное имя клиента.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения клиента.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Дата выдачи водительских прав клиента.
        /// </summary>
        public DateTime DriverLicenseDate { get; set; }

        /// <summary>
        /// Хэш-код пароля пользователя.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Коллекция ролей клиента.
        /// </summary>
        public virtual ICollection<RoleModel> Role { get; set; }

        /// <summary>
        /// Коллекция полисов клиента.
        /// </summary>
        public virtual ICollection<PolicyModel> Policys { get; set; }

        public ClientModel()
        {
            Policys = new HashSet<PolicyModel>();
        }

        /// <summary>
        /// Класс представляет метод конфигурирования сущности Clients.
        /// </summary>
        public class ClientConfiguration : EntityTypeConfiguration<ClientModel>
        {
            /// <summary>
            /// Конфигурация Client.
            /// </summary>
            public ClientConfiguration()
            {
                this.ToTable("Client")
                    .HasMany<PolicyModel>(t => t.Policys)
                    .WithRequired(t => t.Client);
                this.Property(c => c.EMail)
                    .HasMaxLength(50)
                    .IsRequired();
                this.HasKey(c => c.EMail);
                this.Property(c => c.PasswordHash)
                    .HasMaxLength(250);
            }
        }

        /// <summary>
        /// Определяет, равны ли значения этого экземпляра и указанного объекта MainRepository.Models.ClientModels
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

            var clientModel = obj as ClientModel;

            return
                EMail.Equals(clientModel.EMail)
                && Name.Equals(clientModel.Name)
                && BirthDate.Equals(clientModel.BirthDate)
                && DriverLicenseDate.Equals(clientModel.DriverLicenseDate)
                && PasswordHash.Equals(clientModel.PasswordHash);
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
