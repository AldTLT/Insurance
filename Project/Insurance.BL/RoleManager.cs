using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BL
{
    /// <summary>
    /// Класс представляет методы управления типа User.
    /// </summary>
    public class RoleManager
    {
        private readonly IRoleRepository _roleRepository;

        public RoleManager(IRoleRepository roleRipository)
        {
            _roleRepository = roleRipository;
        }

        /// <summary>
        /// Метод возвращает список идентификаторов роли пользователя по e-mail.
        /// </summary>
        /// <param name="email">E-mail пользователя, по которому производится поиск.</param>
        /// <returns>Список идентификаторов роли.</returns>
        public List<int> GetUserRole(string email)
        {
            return _roleRepository.GetUserRole(email);
        }

        /// <summary>
        /// Метод возвращает результат установки доступа пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя, роль которого требуется изменить.</param>
        /// <param name="role">Идентификатор роли пользователя, которую необходимо установить.</param>
        /// <returns>true, если роль успешно установлена, иначе - false.</returns>
        public bool SetUserRole(string email, int role)
        {
            return _roleRepository.SetUserRole(email, role);
        }
    }
}
