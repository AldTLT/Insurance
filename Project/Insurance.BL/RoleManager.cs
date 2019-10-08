using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BL
{
    public class RoleManager
    {
        private readonly IRoleRepository _roleRepository;

        public RoleManager(IRoleRepository roleRipository)
        {
            _roleRepository = roleRipository;
        }

        /// <summary>
        /// Метод возвращает идентификатор роли пользователя по e-mail.
        /// </summary>
        /// <param name="email">E-mail пользователя, по которому производится поиск.</param>
        /// <returns>Идентификатор роли.</returns>
        public int GetUserRole(string email)
        {
            return _roleRepository.GetUserRole(email);
        }

        /// <summary>
        /// Метод возвращает результат установки доступа пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя, роль которого требуется изменить.</param>
        /// <param name="role">Роль пользователя, которую необходимо установить.</param>
        /// <returns>true, если роль успешно установлена, иначе - false.</returns>
        public bool SetUserRole(string email, RoleList role)
        {
            return _roleRepository.SetUserRole(email, role);
        }
    }
}
