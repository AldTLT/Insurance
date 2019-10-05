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
        public Guid? CarId { get; set; }

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
        /// Идентификатор полиса, которому принадлежит автомобиль.
        /// </summary>
        public PolicyModel Policy { get; set; }

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
                    
            }
        }
    }
}
