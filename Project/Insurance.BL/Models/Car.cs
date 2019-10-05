﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BL.Models
{
    public class Car
    {
        /// <summary>
        /// Уникальный идентификатор автомобиля.
        /// </summary>
        public string CarId { get; }

        /// <summary>
        /// Название модели автомобиля.
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// Год выпуска автомобиля.
        /// </summary>
        private int _manufacturedYear;
        public int ManufacturedYear
        {
            get
            {
                return _manufacturedYear;
            }
            set
            {
                if (value > DateTime.Today.Year || value < 1920)
                {
                    throw new ArgumentOutOfRangeException("Некорректный год выпуска автомобиля!");
                }

                _manufacturedYear = value;
            }
        }

        /// <summary>
        /// Стоимость автомобиля.
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
                    throw new ArgumentOutOfRangeException("Стоимость автомобиля не может быть меньше нуля!");

                _cost = value;
            }
        }

        /// <summary>
        /// Мощность двигателя автомобиля в лошадиных силах.
        /// </summary>
        private int _enginePower;
        public int EnginePower
        {
            get
            {
                return _enginePower;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Мощность двигателя автомобиля не может быть меньше нуля!");

                _enginePower = value;
            }
        }

        /// <summary>
        /// Идентификатор полиса, которому принадлежит автомобиль.
        /// </summary>
        public string PolicyId { get; }

        public Car(string carId, string model, int manufacturedYear, int cost, int enginePower, string policyId)
        {
            CarId = carId;
            Model = model;
            ManufacturedYear = manufacturedYear;
            Cost = cost;
            EnginePower = enginePower;
            PolicyId = policyId;
        }

        /// <summary>
        /// Определяет, равны ли значения этого экземпляра и указанного объекта Insurance.BL.Models.Car
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

            var car = obj as Car;

            return
                CarId.Equals(car.CarId)
                && Model.Equals(car.Model)
                && ManufacturedYear.Equals(car.ManufacturedYear)
                && Cost.Equals(car.Cost)
                && EnginePower.Equals(car.EnginePower)
                && PolicyId.Equals(car.PolicyId);
        }

        /// <summary>
        /// Метод возвращает хэш-код объекта.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
        {
            return
                CarId.GetHashCode()
                + Model.GetHashCode()
                + ManufacturedYear.GetHashCode()
                + Cost.GetHashCode()
                + EnginePower.GetHashCode()
                + PolicyId.GetHashCode();
        }
    }
}
