using Insurance.BL;
using Insurance.BL.Models;
using System;
namespace Stub
{
    /// <summary>
    /// Заглушка для тестирования и настройки фронтенда.
    /// </summary>
    public class StubAuthRepository : IAuthRepository
    {
        public bool ChangePassword(string email, string oldPasswordHash, string newPasswordHash)
        {
            return true;
        }

        public User GetUser(string mail)
        {
            var user = new User(
                "vr0rtex@mail.ru",
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
