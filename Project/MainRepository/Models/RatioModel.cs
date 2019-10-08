using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace MainRepository.Models
{
    public class RatioModel
    {
        /// <summary>
        /// Идентификатор набора коэффициентов.
        /// </summary>
        public Guid RatioId { get; set; }

        /// <summary>
        /// Коэффициент возраста автомобиля.
        /// </summary>
        public double CarAge { get; set; }

        /// <summary>
        /// Коэффициент стажа вождения.
        /// </summary>
        public double DrivingExperience { get; set; }

        /// <summary>
        /// Коэффициент возраста водителя.
        /// </summary>
        public double DriverAge { get; set; }

        /// <summary>
        /// Коэффициент мощности двигателя.
        /// </summary>
        public double EnginePower { get; set; }

        /// <summary>
        /// Policy для которого рассчитывается коэффициент.
        /// </summary>
        public PolicyModel Policy { get; set; }

        public class RatioConfiguration : EntityTypeConfiguration<RatioModel>
        {
             public RatioConfiguration()
            {
                this.ToTable("Ratio")
                    .HasRequired(c => c.Policy)
                    .WithOptional(c => c.Ratio);
                this.Property(c => c.RatioId)
                    .IsRequired();
                this.HasKey(c => c.RatioId);
            }
        }

        /// <summary>
        /// Определяет, равны ли значения этого экземпляра и указанного объекта MainRepository.Models.RatioModel.
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

            var ratioModel = obj as RatioModel;

            return
                CarAge.Equals(ratioModel.CarAge)
                && DrivingExperience.Equals(ratioModel.DrivingExperience)
                && DriverAge.Equals(ratioModel.DriverAge)
                && EnginePower.Equals(ratioModel.EnginePower);
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
