using Insurance.BL.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BL.Models;

namespace Insurance.BL
{
    /// <summary>
    /// Класс представляет методы обработки коэффициентов расчета стоимости полиса.
    /// </summary>
    public class RatioManager
    {
        private readonly IRatioRepository _ratioRepository;

        public RatioManager(IRatioRepository ratioRepository)
        {
            _ratioRepository = ratioRepository;
        }

        /// <summary>
        /// Метод возвращает коэффициенты рассчета суммы полиса по номеру автомобиля.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля для поиска.</param>
        /// <returns>Insurance.BL.Models.Ratio</returns>
        public Ratio GetRatio(string carNumber)
        {
            return _ratioRepository.GetRatio(carNumber);
        }
    }
}
