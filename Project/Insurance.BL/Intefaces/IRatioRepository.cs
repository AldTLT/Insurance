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
        /// Метод возвращает итоговую цену, рассчитанную по коеффициентам на основании заданной цены.
        /// </summary>
        /// <param name="ratio">Коэффициенты для рассчета.</param>
        /// <param name="cost">Заданная цена, по которой вычисляется итоговая стоимость.</param>
        /// <returns>Итоговая цена, рассчитанная по коэффициентам.</returns>
        int ToCalculate(Ratio ratio, int cost);
    }
}
