using System;
using System.Runtime.Serialization;
using System.Text;

namespace Insurance.BL.Models
{
    /// <summary>
    /// Класс представляет объект Policy.
    /// </summary>
    [DataContract]
    [KnownType(typeof(Car))]
    [KnownType(typeof(Ratio))]
    public class Policy
    {
        /// <summary>
        /// Уникальный идентификатор полиса.
        /// </summary>
        [DataMember]
        public Guid PolicyId { get; set; }

        /// <summary>
        /// Стоимость полиса.
        /// </summary>
        [DataMember]
        private int _cost;

        [DataMember]
        public int Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Стоимость полиса не может быть меньше нуля!");

                _cost = value;
            }
        }

        /// <summary>
        /// Клиент - владелец полиса.
        /// </summary>
        [DataMember]
        public string UsersEmail { get; private set; }

        /// <summary>
        /// Дата заключения полиса.
        /// </summary>
        [DataMember]
        public DateTime PolicyDate { get; private set; }

        /// <summary>
        /// Экземпляр класса Insurance.BL.Model.Car который привязан к полису.
        /// </summary>
        [DataMember]
        public Car Car { get; private set; }

        /// <summary>
        /// Экземпляр класса Insurance.BL.Model.Coefficient который привязан к полису.
        /// </summary>
        [DataMember]
        public Ratio Ratio { get; private set; }

        public Policy(int cost, string usersEmail, DateTime policyDate, Car car, Ratio ratio)
        {
            Cost = cost;
            UsersEmail = usersEmail.ToLower();
            PolicyDate = policyDate;
            Car = car;
            Ratio = ratio;
        }

        /// <summary>
        /// Определяет, равны ли значения этого экземпляра и указанного объекта Insurance.BL.Models.Policy
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

            var policy = obj as Policy;

            return
                Cost.Equals(policy.Cost)
                && UsersEmail.Equals(policy.UsersEmail)
                && PolicyDate.Equals(policy.PolicyDate);

        }

        /// <summary>
        /// Метод возвращает хэш-код объекта.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
        {
            return
                Cost.GetHashCode()
                + UsersEmail.GetHashCode()
                + PolicyDate.GetHashCode();
        }

        /// <summary>
        /// Метод возвращает строковое представление экземпляра объекта.
        /// </summary>
        /// <returns>Строковое представление экземпляра объекта</returns>
        public override string ToString()
        {
            var policyBuilder = new StringBuilder();

            policyBuilder.Append(UsersEmail).Append(" ");
            policyBuilder.Append(Cost.ToString()).Append(" ");
            policyBuilder.Append(PolicyDate.ToString("dd.MM.yyyy"));

            if (Car != null)
            {
                policyBuilder.Append(" ").Append(Car.CarNumber).Append(" ");
                policyBuilder.Append(Car.Model).Append(" ");
                policyBuilder.Append(Car.Cost).Append(" ");
                policyBuilder.Append(Car.ManufacturedYear).Append(" ");
                policyBuilder.Append(Car.EnginePower);
            }

            if (Ratio != null)
            {
                policyBuilder.Append(" ").Append(Ratio.CarAge).Append(" ");
                policyBuilder.Append(Ratio.DrivingExperience).Append(" ");
                policyBuilder.Append(Ratio.DriverAge).Append(" ");
                policyBuilder.Append(Ratio.EnginePower);
            }

            return policyBuilder.ToString();
        }
    }
}
