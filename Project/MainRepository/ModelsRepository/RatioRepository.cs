using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BL;
using Insurance.BL.Models;
using MainRepository.Models;
using MainRepository.ModelsRepository;
using Insurance.BL.Intefaces;

namespace MainRepository.ModelsRepository
{
    /// <summary>
    /// Класс представляет методы управления RatioModel.
    /// </summary>
    public class RatioRepository : IRatioRepository
    {
        private readonly DataContext _context;

        public RatioRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод возвращает коэффициенты рассчета суммы полиса по номеру автомобиля.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля для поиска.</param>
        /// <returns>Insurance.BL.Models.Ratio</returns>
        public Ratio GetRatio(string carNumber)
        {
            var ratioModel = _context.Coefficients.FirstOrDefault(r => r.Policy.Car.CarNumber.Equals(carNumber));
            var ratioRepository = new RatioRepository(_context);
            return ratioRepository.RatioModelToRatio(ratioModel);
        }

        /// <summary>
        /// Метод возвращает Insurance.BL.Models.Ratio с данными полученными из RatioModel.
        /// </summary>
        /// <param name="policyModel">RatioModel по которому берутся данные.</param>
        /// <returns>Insurance.BL.Models.Ratio с данными из RatioModel.
        /// Если ratioModel == null, метод вернет null.</returns>
        public Ratio RatioModelToRatio(RatioModel ratioModel)
        {
            if (ratioModel == null)
                return null;

            var ratio = new Ratio
                (
                ratioModel.CarAge,
                ratioModel.DrivingExperience,
                ratioModel.DriverAge,
                ratioModel.EnginePower
                );

            return ratio;
        }

        /// <summary>
        /// Метод возвращает RatioModel с данными полученными из Insurance.BL.Models.Ratio.
        /// </summary>
        /// <param name="policy">Insurance.BL.Models.Ratio по которому берутся данные.</param>
        /// <returns>RatioModel с данными из Insurance.BL.Models.Ratio.
        /// Если Ratio == null, метод вернет null.</returns>
        public RatioModel RatioToRatioModel(Ratio ratio)
        {
            if (ratio == null)
                return null;

            var ratioModel = new RatioModel()
            {
                CarAge = ratio.CarAge,
                DrivingExperience = ratio.DrivingExperience,
                DriverAge = ratio.DriverAge,
                EnginePower = ratio.EnginePower
            };

            return ratioModel;
        }
    }
}
