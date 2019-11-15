using Insurance.BL;
using System.Collections.Generic;

namespace Stub
{
    /// <summary>
    /// Заглушка для тестирования и настройки фронтенда.
    /// </summary>
    public class StubRoleRepository : IRoleRepository
    {
        public List<string> GetUserRole(string email)
        {
            return new List<string> { "user", "administrator" };
        }

        public bool SetUserRole(string email, string role)
        {
            return true;
        }
    }
}
