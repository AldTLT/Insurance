using System.Collections.Generic;

namespace Insurance.BL
{
    /// <summary>
    /// Интерфейс представляет методы управления ролями пользователей.
    /// </summary>
    public interface IRoleRepository
    {
        /// <summary>
        /// Метод возвращает список идентификаторов роли пользователя по e-mail.
        /// </summary>
        /// <param name="email">E-mail пользователя, по которому производится поиск.</param>
        /// <returns>Список идентификаторов роли.</returns>
        List<string> GetUserRole(string email);

        /// <summary>
        /// Метод возвращает результат установки доступа пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя, роль которого требуется изменить.</param>
        /// <param name="role">Идентификатор роли пользователя, которую необходимо установить.</param>
        /// <returns>true, если роль успешно установлена, иначе - false.</returns>
        bool SetUserRole(string email, string role);
    }
}
