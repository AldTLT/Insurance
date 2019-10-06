﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainRepository;
using Insurance.BL.Models;
using MainRepository.Models;

namespace MainRepositoryTest
{
    [TestClass]
    public class PolicyRepositoryTest
    {
        DataContext _dataContext = new DataContext();
        PolicyRepository _policyRepository;
        ClientModel _client;
        User _user;

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
                "qwerty",
                1000,
                "test1@yandex.ru",
                new DateTime(2019, 12, 01),
                null   
                );

            var policyModel = new PolicyModel()
            {
                PolicyID = "qwerty",
                Cost = 1000,
                ClientEmail = "test1@yandex.ru",
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
                PolicyID = "qwerty",
                Cost = 1000,
                ClientEmail = "test1@yandex.ru",
                PolicyDate = new DateTime(2019, 12, 01),
                Car = null
            };

            var policy = new Policy(
                "qwerty",
                1000,
                "test1@yandex.ru",
                new DateTime(2019, 12, 01),
                null
                );

            var policyModel = _policyRepository.PolicyToPolicyModel(policy);

            Assert.AreEqual(expectedPolicyModel, policyModel);
        }

        [TestMethod]
        public void PolicyRegistrationTest()
        {
            var car = new Car
                (
                "Ford",
                2018,
                900000,
                105,
                null
                );
                 
            var policy = new Policy(
                "0009",
                1000,
                "test@yandex.ru",
                new DateTime(2019, 12, 01),
                car
                );

            car.Policy = policy;

            Assert.IsTrue(_policyRepository.PolicyRegistration(policy));
        }
    }
}
