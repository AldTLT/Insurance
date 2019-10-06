using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BL.Models
{
    public class Car
    {
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
        public Policy Policy { get; set; }

        public Car(string model, int manufacturedYear, int cost, int enginePower, Policy policy)
        {
            Model = model;
            ManufacturedYear = manufacturedYear;
            Cost = cost;
            EnginePower = enginePower;
            Policy = policy;
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

            //Проверка объектов Policy.
            var policyEqual = Policy == null && car.Policy == null ? true
                : Policy != null && car.Policy == null ? false
                : Policy == null && car.Policy != null ? false
                : Policy.Equals(car.Policy) ? true : false;

            return
                Model.Equals(car.Model)
                && ManufacturedYear.Equals(car.ManufacturedYear)
                && Cost.Equals(car.Cost)
                && EnginePower.Equals(car.EnginePower)
                && Policy.Equals(car.Policy);
        }

        /// <summary>
        /// Метод возвращает хэш-код объекта.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
        {
            return
                Model.GetHashCode()
                + ManufacturedYear.GetHashCode()
                + Cost.GetHashCode()
                + EnginePower.GetHashCode()
                + Policy.GetHashCode();
        }
    }
}
