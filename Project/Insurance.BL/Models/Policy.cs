﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BL.Models
{
    public class Policy
    {
        /// <summary>
        /// Идентификатор полиса, первичный ключ.
        /// </summary>
        public string PolicyID { get; }

        /// <summary>
        /// Стоимость полиса.
        /// </summary>
        private int _cost;
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
        public string UsersEmail { get; }

        /// <summary>
        /// Дата заключения полиса.
        /// </summary>
        private DateTime _policyDate;
        public DateTime PolicyDate
        {
            get
            {
                return _policyDate;
            }
            private set
            {
                if (value < DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException("Дата заключения полиса не может быть раньше сегодняшней даты!");
                }

                _policyDate = value;
            }
        }

        /// <summary>
        /// Экземпляр класса Insurance.BL.Model.Car который привязан к полису.
        /// </summary>
        public Car Car { get; }

        public Policy(string id, int cost, string usersEmail, DateTime policyDate, Car car)
        {
            PolicyID = id;
            Cost = cost;
            UsersEmail = usersEmail;
            PolicyDate = policyDate;
            Car = car;
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

            //Проверка объектов Car.
            var carEqual = Car == null && policy.Car == null ? true
                : Car != null && policy.Car == null ? false
                : Car == null && policy.Car != null ? false
                : Car.Equals(policy.Car) ? true : false;

            return
                PolicyID.Equals(policy.PolicyID)
                && Cost.Equals(policy.Cost)
                && UsersEmail.Equals(policy.UsersEmail)
                && PolicyDate.Equals(policy.PolicyDate)
                && carEqual;
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
                + UsersEmail.GetHashCode()
                + PolicyDate.GetHashCode()
                + Car.GetHashCode();
        }

    }
}
