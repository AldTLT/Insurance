using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainRepository;
using Insurance.BL.Models;
using MainRepository.Models;

namespace MainRepositoryTest
{
    [TestClass]
    public class PolicyRepositoryTest
    {
        private readonly DataContext _dataContext = new DataContext();
        private PolicyRepository _policyRepository;
        private ClientModel _client;
        private User _user;

        /// <summary>
        /// Инициализация объекта.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _policyRepository = new PolicyRepository(_dataContext);

            _client = new ClientModel()
            {
                EMail = "test@yandex.ru",
                Name = "Иванов Иван Иванович",
                BirthDate = new DateTime(1990, 01, 01),
                DriverLicenseDate = new DateTime(2011, 05, 07),
                PasswordHash = "pass123"
            };

            _user = new User(
                "test@yandex.ru",
                "Иванов Иван Иванович",
                new DateTime(1990, 01, 01),
                new DateTime(2011, 05, 07),
                "pass123"
                );
        }

        /// <summary>
        /// Тест метода PolicyModelToPolicy.
        /// </summary>
        [TestMethod]
        public void PolicyModelToPolicyTest()
        {
            var expectedPolicy = new Policy(
                1000,
                "test@yandex.ru",
                new DateTime(2019, 12, 01),
                null,
                null
                );

            var policyModel = new PolicyModel()
            {
                policyCost = 1000,
                ClientEmail = "test@yandex.ru",
                PolicyDate = new DateTime(2019, 12, 01)
            };

            var policy = _policyRepository.PolicyModelToPolicy(policyModel);

            Assert.AreEqual(expectedPolicy, policy);
        }

        /// <summary>
        /// Тест метода PolicyToPolicyModel.
        /// </summary>
        [TestMethod]
        public void PolicyToPolicyModelTest()
        {
            var expectedPolicyModel = new PolicyModel()
            {
                policyCost = 1000,
                ClientEmail = "test@yandex.ru",
                PolicyDate = new DateTime(2019, 12, 01),
                Car = null
            };

            var policy = new Policy(
                1000,
                "test@yandex.ru",
                new DateTime(2019, 12, 01),
                null,
                null
                );

            var policyModel = _policyRepository.PolicyToPolicyModel(policy);

            Assert.AreEqual(expectedPolicyModel, policyModel);
        }

        [TestMethod]
        public void PolicyRegistrationTest()
        {
            var ratio = new Ratio
                (
                1.0,
                0.5,
                2,
                0.8
                );

            var car = new Car
                (
                "XX777O163RU",
                "Ford",
                2018,
                900000,
                105
                );
                 
            var policy = new Policy(
                1000,
                "test@mail.ru",
                new DateTime(2019, 12, 01),
                car,
                ratio
                );

            Assert.IsTrue(_policyRepository.PolicyRegistration(policy).Equals("XX777O163RU"));
        }
    }
}
