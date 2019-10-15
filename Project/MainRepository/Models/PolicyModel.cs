

using System;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainRepository.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainRepository.Models
{
    public class PolicyModel
    {
        /// <summary>
        /// Идентификатор полиса, первичный ключ.
        /// </summary>
        public Guid PolicyID { get; set; }

        /// <summary>
        /// Стоимость полиса.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Дата заключения полиса.
        /// </summary>
        public DateTime PolicyDate { get; set; }

        /// <summary>
        /// Клиент - владелец полиса.
        /// </summary>
        public virtual ClientModel Client { get; set; }

        /// <summary>
        /// Идентификатор автомобиля.
        /// </summary>
        public virtual CarModel Car { get; set; }

        /// <summary>
        /// Коэффициенты для рассчета.
        /// </summary>
        public virtual RatioModel Ratio { get; set; }

        /// <summary>
        /// E-mail клиента. Свойство используется для поиска ClientModel.
        /// </summary>
        public virtual string ClientEmail { get; set; }

        /// <summary>
        /// Класс представляет метод конфигурирования PolicyModel.
        /// </summary>
        public class PolicyConfiguration : EntityTypeConfiguration<PolicyModel>
        {
            public PolicyConfiguration()
            {
                this.ToTable("Policy")
                    .HasRequired<ClientModel>(t => t.Client);
                this.Property(p => p.PolicyID)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                this.Property(p => p.PolicyID)
                    .IsRequired();
                this.HasKey(p => p.PolicyID);
                this.Ignore(p => p.ClientEmail);
             }
        }

        /// <summary>
        /// Определяет, равны ли значения этого экземпляра и указанного объекта MainRepository.Models.PolicyModels
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

            var policyModel = obj as PolicyModel;

            return
                PolicyID.Equals(policyModel.PolicyID)
                && Cost.Equals(policyModel.Cost)
                && PolicyDate.Equals(policyModel.PolicyDate);         
        }

        /// <summary>
        /// Метод возвращает хэш-код объекта.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
        {
            return
                PolicyID.GetHashCode()
                + Cost.GetHashCode()
                + PolicyDate.GetHashCode();
        }
    }
}
