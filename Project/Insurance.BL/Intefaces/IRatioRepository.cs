using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BL.Models;

namespace Insurance.BL.Intefaces
{
    public interface IRatioRepository
    {
        /// <summary>
        /// Метод возвращает коэффициенты рассчета суммы полиса по номеру автомобиля.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля для поиска.</param>
        /// <returns>Insurance.BL.Models.Ratio</returns>
        Ratio GetRatio(string carNumber);

    }
}
