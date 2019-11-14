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
        //Экземпляр класса, реализующего интерфейс IRoleRepository.
        private readonly IRoleRepository _roleRepository;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="roleRipository">Репозиторий, реализующий интерфейс IRoleRepository.</param>
        public RoleManager(IRoleRepository roleRipository)
        {
            _roleRepository = roleRipository;
        }

        /// <summary>
        /// Метод возвращает список идентификаторов роли пользователя по e-mail.
        /// </summary>
        /// <param name="email">E-mail пользователя, по которому производится поиск.</param>
        /// <returns>Список идентификаторов роли.</returns>
        public List<string> GetUserRole(string email)
        {
            return _roleRepository.GetUserRole(email.ToLower());
        }

        /// <summary>
        /// Метод возвращает результат установки доступа пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя, роль которого требуется изменить.</param>
        /// <param name="role">Идентификатор роли пользователя, которую необходимо установить.</param>
        /// <returns>true, если роль успешно установлена, иначе - false.</returns>
        public bool SetUserRole(string email, string role)
        {
            return _roleRepository.SetUserRole(email.ToLower(), role.ToLower());
        }
    }
}
