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
    public class RatioRepository : IRatioRepository
    {
        private readonly DataContext _context;

        public RatioRepository(DataContext context)
        {
            _context = context;
        }

        public int ToCalculate(Ratio ratio, int cost)
        {
            throw new NotImplementedException();
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
