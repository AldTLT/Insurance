using Insurance.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BL
{
    /// <summary>
    /// Класс представляет методы управления типа Policy.
    /// </summary>
    public class PolicyManager
    {
        /// <summary>
        /// Экземпляр класса, реализующего интерфейс IPolicyRepository.
        /// </summary>
        private readonly IPolicyRepository _policyRepository;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="policyRepository">Репозиторий, реализующий интерфейс IPolicyRepository.</param>
        public PolicyManager(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        /// <summary>
        /// Метод возвращает коллекцию всех Insurance.BL.Models.Policy, соответствующих email.
        /// </summary>
        /// <param name="email">Email по которому осуществляется поиск.</param>
        /// <returns>ICollection<Policy> соответствующих email.</returns>
        public ICollection<Policy> GetPolicys(string email)
        {
            var lowerEmail = email.ToLower();
            return lowerEmail.IsEmailCorrect() ? _policyRepository.GetPolicys(lowerEmail) : null;
        }

        /// <summary>
        /// Метод возвращает результат добавления нового полиса в систему.
        /// </summary>
        /// <param name="policy">Insurance.BL.Models.Policy для добавления в систему.</param>
        /// <returns>true, если полис успешно добавлен, иначе - false.</returns>
        public bool PolicyRegistration(Policy policy)
        {
            return _policyRepository.PolicyRegistration(policy);
        }

        /// <summary>
        /// Метод возвращает экземпляр Insurance.BL.Models.Policy по номеру автомобиля.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля, по которому производится поиск полиса.</param>
        /// <returns>Insurance.BL.Models.Policy, если номер существует в базе данных, иначе - null.</returns>
        public Policy GetPolicy(string carNumber)
        {
            var carNumberUpperLetters = carNumber.ToUpper();
            return carNumberUpperLetters.IsCarNumberCorrect() ? _policyRepository.GetPolicy(carNumberUpperLetters) : null;
        }
    }
}
