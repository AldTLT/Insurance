using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BL
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Метод возвращает идентификатор роли пользователя по e-mail.
        /// </summary>
        /// <param name="email">E-mail пользователя, по которому производится поиск.</param>
        /// <returns>Идентификатор роли.</returns>
        int GetUserRole(string email);
    }
}
