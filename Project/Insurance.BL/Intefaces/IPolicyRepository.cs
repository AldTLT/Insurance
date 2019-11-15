using System.Collections.Generic;
using Insurance.BL.Models;

namespace Insurance.BL
{
    /// <summary>
    /// Интерфейс представляет методы управления полисом.
    /// </summary>
    public interface IPolicyRepository
    {
        /// <summary>
        /// Метод возвращает коллекцию всех Insurance.BL.Models.Policy, соответствующих email.
        /// </summary>
        /// <param name="email">Email по которому осуществляется поиск.</param>
        /// <returns>ICollection<Policy> соответствующих email.</returns>
        ICollection<Policy> GetPolicys(string email);

        /// <summary>
        /// Метод возвращает результат добавления нового полиса в систему.
        /// </summary>
        /// <param name="policy">Insurance.BL.Models.Policy для добавления в систему.</param>
        /// <returns>Номер полиса, если полис успешно добавлен, иначе - null.</returns>
        string PolicyRegistration(Policy policy);

        /// <summary>
        /// Метод возвращает экземпляр Insurance.BL.Models.Policy по номеру автомобиля.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля, по которому производится поиск полиса.</param>
        /// <returns>Insurance.BL.Models.Policy, если номер существует в базе данных, иначе - null.</returns>
        Policy GetPolicy(string carNumber);
    }
}
