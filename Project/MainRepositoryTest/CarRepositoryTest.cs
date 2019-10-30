using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainRepository;
using Insurance.BL.Models;
using MainRepository.Models;
using MainRepository.ModelsRepository;

namespace MainRepositoryTest
{
    [TestClass]
    public class CarRepositoryTest
    {
        private readonly DataContext _dataContext = new DataContext();
        private CarRepository _carRepository;

        /// <summary>
        /// Инициализация данных перед тестами.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _carRepository = new CarRepository(_dataContext);
        }

        /// <summary>
        /// Тесто метода CarToCarModel.
        /// </summary>
        [TestMethod]
        public void CarToCarModelTest()
        {
            var expectedCarModel = new CarModel()
            {
                CarNumber = "TEST99963",
                Model = "Kalina",
                ManufacturedYear = 2017,
                Cost = 500000,
                EnginePower = 88
            };

            var car = new Car
                (
                "TEST99963",
                "Kalina",
                2017,
                500000,
                88
                );

            var carModel = _carRepository.CarToCarModel(car);

            Assert.AreEqual(expectedCarModel, carModel);
        }

        /// <summary>
        /// Тест метода CarModelToCar.
        /// </summary>
        [TestMethod]
        public void CarModelToCarTest()
        {
            var expectedCar = new Car
                (
                "999TEST63",
                "FIAT",
                2019,
                600000,
                102
                );

            var carModel = new CarModel()
            {
                CarNumber = "999TEST63",
                Model = "FIAT",
                ManufacturedYear = 2019,
                Cost = 600000,
                EnginePower = 102
            };

            var car = _carRepository.CarModelToCar(carModel);

            Assert.AreEqual(expectedCar, car);
        }
    }
}
