using Insurance.BL;
using Insurance.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    /// <summary>
    /// Заглушка для тестирования и настройки фронтенда.
    /// </summary>
    public class StubCarRepository : ICarRepository
    {
        public Car GetCar(string carNumber)
        {
            return new Car("777TEST163RU", "Vesta", 2018, 750000, 104);
        }
    }
}
