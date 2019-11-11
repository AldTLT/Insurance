using Insurance.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
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
