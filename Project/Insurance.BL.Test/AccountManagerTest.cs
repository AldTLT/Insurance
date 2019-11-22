using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Insurance.BL.Models;
using MainRepository;

namespace Insurance.BL.Test
{
    [TestClass]
    public class AccountManagerTest
    {
        /// <summary>
        /// Тест проверяет метод SignIn.
        /// </summary>
        [DataTestMethod]
        [DataRow(true, "123@mail.ru", "123")]
        [DataRow(false, "124@mail.ru", "123")]
        [DataRow(false, "123@mail.ru", "124")]
        public void SignInTest(bool expectedResult, string email, string passwordHash)
        {
            var repository = new AuthRepository();
            var manager = new AccountManager(repository);

            Assert.AreEqual(expectedResult, manager.SignIn(email, passwordHash));
        }

        [TestMethod]
        public void CreateNewClientTest()
        {
            var repository = new AuthRepository();
            var manager = new AccountManager(repository);

            var user = new User(
                "test@yandex.ru",
                "Иванов Иван Иванович",
                new DateTime(1990, 01, 01),
                new DateTime(2011, 05, 07),
                "pass123"
    );

            Assert.IsTrue(manager.Registration(user));
        }
    }
}
