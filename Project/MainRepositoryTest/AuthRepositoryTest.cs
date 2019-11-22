using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainRepository;
using Insurance.BL.Models;
using MainRepository.Models;

namespace MainRepositoryTest
{
    /// <summary>
    /// Класс представляет юнит-тесты AuthRepository методов.
    /// </summary>
    [TestClass]
    public class AuthRepositoryTest
    {
        DataContext _dataContext = new DataContext();
        AuthRepository _authRepository;
        
        /// <summary>
        /// Инициализация объекта.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _authRepository = new AuthRepository();
        }

        /// <summary>
        /// Тест метода UserToClientModel.
        /// </summary>
        [TestMethod]
        public void UserToClientModelTest()
        {
            var expectedClientModel = new ClientModel()
            {
                EMail = "test@yandex.ru",
                Name = "Иванов Иван Иванович",
                BirthDate = new DateTime(1990, 01, 01),
                DriverLicenseDate = new DateTime(2011, 05, 07),
                PasswordHash = "pass123"
            };

            var user = new User(
                "test@yandex.ru", 
                "Иванов Иван Иванович", 
                new DateTime(1990, 01, 01), 
                new DateTime(2011, 05, 07), 
                "pass123");

            var clientModel = _authRepository.UserToClientModel(user);


            Assert.AreEqual(expectedClientModel, clientModel);
        }

        /// <summary>
        /// Тест метода ClientModelToUser
        /// </summary>
        [TestMethod]
        public void ClientModelToUserTest()
        {
            var expectedUser = new User(
                "test@yandex.ru", 
                "Иванов Иван Иванович", 
                new DateTime(1990, 01, 01), 
                new DateTime(2011, 05, 07), 
                "pass123");

            var clientModel = new ClientModel()
            {
                EMail = "test@yandex.ru",
                Name = "Иванов Иван Иванович",
                BirthDate = new DateTime(1990, 01, 01),
                DriverLicenseDate = new DateTime(2011, 05, 07),
                PasswordHash = "pass123"
            };

            var user = _authRepository.ClientModelToUser(clientModel);

            Assert.AreEqual(expectedUser, user);
        }

        /// <summary>
        /// Тест метода GetUser.
        /// </summary>
        [TestMethod]
        public void GetUserTest()
        {
            var expectedUser = new User
                (
                "test@mail.ru",
                "Василий Пупкин",
                new DateTime(1990, 10, 10),
                new DateTime(2010, 10, 10),
                "123"
                );

            var user = _authRepository.GetUser("test@mail.ru");

            Assert.AreEqual(expectedUser, user);
        }

        [TestMethod]
        public void ClientRegistrationTest()
        {
            var user = new User
                (
                "test4@mail.ru",
                "Василий Пупкин",
                new DateTime(1990, 10, 10),
                new DateTime(2010, 10, 10),
                "123"
                );

            Assert.IsTrue(_authRepository.Registration(user));
        }
    }
}
