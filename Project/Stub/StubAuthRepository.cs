using Insurance.BL;
using Insurance.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    public class StubAuthRepository : IAuthRepository
    {
        public User GetUser(string mail)
        {
            var user = new User(
                "test@mail.ru",
                "Vasily Pupkin",
                new DateTime(1980, 10, 13),
                new DateTime(2010, 02, 05),
                "qwerty123");

            user.Role.Add("admin");

            return user;
        }

        public bool Registration(User client)
        {
            return true;
        }

        public bool SignIn(string email, string passwordHash)
        {
            return true;
        }
    }
}
