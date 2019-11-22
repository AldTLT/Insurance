using System;
using System.Runtime.Serialization;

namespace Insurance.BL.Models
{
    /// <summary>
    /// Класс представляет объект Car.
    /// </summary>
    [DataContract]
    public class Car
    {
        /// <summary>
        /// Номер автомобиля.
        /// </summary>
        [DataMember]
        public string CarNumber { get; private set; }

        /// <summary>
        /// Название модели автомобиля.
        /// </summary>
        [DataMember]
        public string Model { get; private set; }

        /// <summary>
        /// Год выпуска автомобиля.
        /// </summary>
        private int _manufacturedYear;

        [DataMember]
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
                    throw new ArgumentOutOfRangeException("Стоимость автомобиля не может быть меньше нуля!");

                _cost = value;
            }
        }

        /// <summary>
        /// Мощность двигателя автомобиля в лошадиных силах.
        /// </summary>
        [DataMember]
        private int _enginePower;

        [DataMember]
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

        public Car(string carNumber, string model, int manufacturedYear, int cost, int enginePower)
        {
            CarNumber = carNumber.ToUpper();
            Model = model.ToUpper();
            ManufacturedYear = manufacturedYear;
            Cost = cost;
            EnginePower = enginePower;
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
                CarNumber.Equals(car.CarNumber)
                && Model.Equals(car.Model)
                && ManufacturedYear.Equals(car.ManufacturedYear)
                && Cost.Equals(car.Cost)
                && EnginePower.Equals(car.EnginePower);
        }

        /// <summary>
        /// Метод возвращает хэш-код объекта.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
        {
            return
                CarNumber.GetHashCode()
                + Model.GetHashCode()
                + ManufacturedYear.GetHashCode()
                + Cost.GetHashCode()
                + EnginePower.GetHashCode();
        }
    }
}
