using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BL.Models;

namespace Insurance.BL
{
    public interface IPolicyRepository
    {
        /// <summary>
        /// Метод возвращает коллекцию всех Insurance.BL.Models.Policy, соответствующих email.
        /// </summary>
        /// <param name="email">Email по которому осуществляется поиск.</param>
        /// <returns>ICollection<Policy> соответствующих email.</returns>
        ICollection<Policy> GetPolicy(string email);

    }
}
