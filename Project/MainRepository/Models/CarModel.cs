using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainRepository.Models
{
    public class CarModel
    {
        /// <summary>
        /// Уникальный идентификатор автомобиля.
        /// </summary>
        public Guid CarId { get; set; }

        /// <summary>
        /// Название модели автомобиля.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Год выпуска автомобиля.
        /// </summary>
        public int ManufacturedYear { get; set; }

        /// <summary>
        /// Стоимость автомобиля.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Мощность двигателя автомобиля в лошадиных силах.
        /// </summary>
        public int EnginePower { get; set; }

        /// <summary>
        /// Полис привязки к автомобилю.
        /// </summary>
        public PolicyModel Policy { get; set; }

        /// <summary>
        /// Идентификатор полиса, которому привязан автомобиль.
        /// Свойство используется для быстрого поиска PolicyModel.
        /// </summary>
        public Guid PolicyId { get; set; }

        /// <summary>
        /// Класс представляет метод конфигурирования CarModel.
        /// </summary>
        public class CarConfiguration : EntityTypeConfiguration<CarModel>
        {
            public CarConfiguration()
            {
                this.ToTable("Car")
                    .HasRequired(c => c.Policy)
                    .WithRequiredDependent(c => c.Car);
                this.Property(c => c.Model)
                    .HasMaxLength(50);
                this.Property(c => c.CarId)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                this.HasKey(c => c.CarId);
                this.Ignore(c => c.PolicyId);
                    
            }
        }

        /// <summary>
        /// Определяет, равны ли значения этого экземпляра и указанного объекта MainRepository.Models.CarModels
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

            var carModel = obj as CarModel;

            return
                CarId.Equals(carModel.CarId)
                && Model.Equals(carModel.Model)
                && ManufacturedYear.Equals(carModel.ManufacturedYear)
                && Cost.Equals(carModel.Cost)
                && EnginePower.Equals(carModel.EnginePower)
                && PolicyId.Equals(carModel.PolicyId);
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
