using System;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainRepository.Models;

namespace MainRepository.Models
{
    public class PolicyModel
    {
        /// <summary>
        /// Идентификатор полиса, первичный ключ.
        /// </summary>
        public string PolicyID { get; set; }

        /// <summary>
        /// Стоимость полиса.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Клиент - владелец полиса.
        /// </summary>
        public ClientModel Client { get; set; }

        /// <summary>
        /// Дата заключения полиса.
        /// </summary>
        public DateTime PolicyDate { get; set; }

        /// <summary>
        /// Класс представляет метод конфигурирования сущности Policys.
        /// </summary>
        public class PolicyConfiguration : EntityTypeConfiguration<PolicyModel>
        {
            public PolicyConfiguration()
            {
                this.ToTable("Policy")
                    .HasRequired(t => t.Client);
                this.Property(p => p.PolicyID)
                    .IsRequired();
                this.HasKey(p => p.PolicyID);
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
                && Client.Equals(policyModel.Client)
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
                + Client.GetHashCode()
                + PolicyDate.GetHashCode();
        }
    }
}
