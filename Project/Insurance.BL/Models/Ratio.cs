﻿using System.Runtime.Serialization;

namespace Insurance.BL.Models
{
    /// <summary>
    /// Класс представляет объект Ratio.
    /// </summary>
    [DataContract]
    public class Ratio
    {
        /// <summary>
        /// Коэффициент возраста автомобиля.
        /// </summary>
        [DataMember]
        public double CarAge { get; private set; }

        /// <summary>
        /// Коэффициент стажа вождения.
        /// </summary>
        [DataMember]
        public double DrivingExperience { get; private set; }

        /// <summary>
        /// Коэффициент возраста водителя.
        /// </summary>
        [DataMember]
        public double DriverAge { get; private set; }

        /// <summary>
        /// Коэффициент мощности двигателя.
        /// </summary>
        [DataMember]
        public double EnginePower { get; private set; }

        public Ratio(double carAge, double drivingExperience, double driverAge, double enginePower)
        {
            CarAge = carAge;
            DrivingExperience = drivingExperience;
            DriverAge = driverAge;
            EnginePower = enginePower;
        }

        /// <summary>
        /// Определяет, равны ли значения этого экземпляра и указанного объекта Insurance.BL.Models.Ratio.
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

            var coefficient = obj as Ratio;

            return
                CarAge.Equals(coefficient.CarAge)
                && DrivingExperience.Equals(coefficient.DrivingExperience)
                && DriverAge.Equals(coefficient.DriverAge)
                && EnginePower.Equals(coefficient.EnginePower);
        }

        /// <summary>
        /// Метод возвращает хэш-код объекта.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
        {
            return
                CarAge.GetHashCode()
                + DrivingExperience.GetHashCode()
                + DriverAge.GetHashCode()
                + EnginePower.GetHashCode();
        }
    }
}
