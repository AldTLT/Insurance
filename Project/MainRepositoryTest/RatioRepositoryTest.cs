using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainRepository;
using Insurance.BL.Models;
using MainRepository.Models;
using MainRepository.ModelsRepository;

namespace MainRepositoryTest
{
    [TestClass]
    public class RatioRepositoryTest
    {
        private readonly DataContext _dataContext = new DataContext();
        private RatioRepository _ratioRepository;

        /// <summary>
        /// Инициализация данных перед тестами.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _ratioRepository = new RatioRepository(_dataContext);
        }

        /// <summary>
        /// Тест метода RatioToRatioModel.
        /// </summary>
        [TestMethod]
        public void RatioToRatioModelTest()
        {
            var expectedRatioModel = new RatioModel()
            {
                CarAge = 0.9,
                DrivingExperience = 1.1,
                DriverAge = 1.0,
                EnginePower = 0.8
            };

            var ratio = new Ratio
                (
                0.9,
                1.1,
                1.0,
                0.8
                );

            var ratioModel = _ratioRepository.RatioToRatioModel(ratio);

            Assert.AreEqual(expectedRatioModel, ratioModel);
        }

        /// <summary>
        /// Тест метода RatioModelToRatio.
        /// </summary>
        [TestMethod]
        public void RatioModelToRatioTest()
        {
            var expectedRatio = new Ratio
                (
                1.2,
                1.8,
                0.5,
                2.0
                );

            var ratioModel = new RatioModel()
            {
                CarAge = 1.2,
                DrivingExperience = 1.8,
                DriverAge = 0.5,
                EnginePower = 2.0
            };

            var ratio = _ratioRepository.RatioModelToRatio(ratioModel);

            Assert.AreEqual(expectedRatio, ratio);
        }
    }
}
