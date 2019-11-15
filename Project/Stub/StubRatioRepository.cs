using Insurance.BL.Intefaces;
using Insurance.BL.Models;

namespace Stub
{
    /// <summary>
    /// Заглушка для тестирования и настройки фронтенда.
    /// </summary>
    public class StubRatioRepository : IRatioRepository
    {
        public Ratio GetRatio(string carNumber)
        {
            return new Ratio(1.2, 1.1, 0.8, 1.0);
        }
    }
}
