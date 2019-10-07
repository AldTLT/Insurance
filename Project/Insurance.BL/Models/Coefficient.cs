﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BL.Models
{
    public class Coefficient
    {
        /// <summary>
        /// Коэффициент возраста автомобиля.
        /// </summary>
        public double CarAge { get; }

        /// <summary>
        /// Коэффициент стажа вождения.
        /// </summary>
        public double DrivingExperience { get; }

        /// <summary>
        /// Коэффициент возраста водителя.
        /// </summary>
        public double DriverAge { get; }

        /// <summary>
        /// Коэффициент мощности двигателя.
        /// </summary>
        public double EnginePower { get; }

        public Coefficient(double carAge, double drivingExperience, double driverAge, double enginePower)
        {
            CarAge = carAge;
            DrivingExperience = drivingExperience;
            DriverAge = driverAge;
            EnginePower = enginePower;
        }

        /// <summary>
        /// Определяет, равны ли значения этого экземпляра и указанного объекта Insurance.BL.Models.Coefficient.
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

            var coefficient = obj as Coefficient;

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
