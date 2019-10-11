﻿using Insurance.BL.Models;
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
        private readonly IPolicyRepository _policyRepository;

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
            return _policyRepository.GetPolicy(email);
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
    }
}
