using Insurance.BL.Models;

namespace Insurance.BL.Intefaces
{
    /// <summary>
    /// Интерфейс представляет методы управления рассчетом коэффициентов.
    /// </summary>
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
