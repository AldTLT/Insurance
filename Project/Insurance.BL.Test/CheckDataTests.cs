using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Insurance.BL;
using MainRepository;

namespace Insurance.BL.Test
{
    /// <summary>
    /// Юнит-тесты класса проверки данных.
    /// </summary>
    [TestClass]
    public class CheckDataTests
    {
        /// <summary>
        /// Тест проверяет корректность номера автомобиля.
        /// </summary>
        /// <param name="expectedResult">Ожидаемый результат проверки.</param>
        /// <param name="carNUmber">Номер автомобиля.</param>
        [DataTestMethod]
        [DataRow(true, "V2144BNE")]
        [DataRow(true, "125563")]
        [DataRow(true, "SKKFMAWE")]
        [DataRow(true, "12HHH5")]
        [DataRow(true, "fgldl678")]
        [DataRow(false, "!23DFFG3")]
        [DataRow(false, "1a")]
        [DataRow(false, "123456gfdemn98gh")]
        [DataRow(true, "1234567890qwert")]
        [DataRow(false, "-=45jjjd")]
        public void IsCarNumberCorrectTest(bool expectedResult, string carNUmber)
        {
            Assert.AreEqual(expectedResult, carNUmber.IsCarNumberCorrect());
        }

        /// <summary>
        /// Тест проверяет корректность формата e-mail.
        /// </summary>
        /// <param name="expectedResult">Ожидаемый результат проверки.</param>
        /// <param name="email">E-mail</param>
        [DataTestMethod]
        [DataRow(true, "123@mail.ru")]
        [DataRow(false, "124@mail")]
        [DataRow(false, "@mail.ru")]
        [DataRow(false, "Test@mail.ru#")]
        [DataRow(true, "vasiliy123_pupkin!@home.room.bed")]
        public void IsMailCorrectTest(bool expectedResult, string email)
        {
            Assert.AreEqual(expectedResult, email.IsEmailCorrect());
        }

        /// <summary>
        /// Тест проверяет корректность дату рождения.
        /// </summary>
        [TestMethod]
        public void IsBirthDateCorrect()
        {
            var date = DateTime.Today;
            Assert.IsFalse(date.IsBirthDateCorrect());

            date = new DateTime(1919, 01, 01);
            Assert.IsFalse(date.IsBirthDateCorrect());

            date = new DateTime(1990, 10, 3);
            Assert.IsTrue(date.IsBirthDateCorrect());
        }

        /// <summary>
        /// Тест проверяет корректность дату рождения.
        /// </summary>
        [TestMethod]
        public void IsDriverLicenseDateCorrect()
        {
            //Дата - сегодня + 1 день.
            var date = DateTime.Today + new TimeSpan(1, 0, 0, 0);
            Assert.IsFalse(date.IsDriverLicenseDateCorrect());

            date = new DateTime(1919, 01, 01);
            Assert.IsFalse(date.IsDriverLicenseDateCorrect());

            date = new DateTime(1990, 10, 3);
            Assert.IsTrue(date.IsDriverLicenseDateCorrect());
        }

        /// <summary>
        /// Тест проверяет корректность год выпуска автомобиля.
        /// </summary>
        /// <param name="expectedResult">Ожидаемый результат проверки.</param>
        /// <param name="manufacturedYear">Год выпуска автомобиля.</param>
        [DataTestMethod]
        [DataRow(false, 2020)]
        [DataRow(true, 2019)]
        [DataRow(false, 1919)]
        [DataRow(true, 1930)]

        public void IsManufacturedYearCorrectTest(bool expectedResult, int manufacturedYear)
        {
            Assert.AreEqual(expectedResult, manufacturedYear.IsManufacturedYearCorrect());
        }

        /// <summary>
        /// Тест проверяет корректность мощность двигателя автомобиля.
        /// </summary>
        /// <param name="expectedResult">Ожидаемый результат проверки.</param>
        /// <param name="enginePower">Мощность двигателя автомобиля.</param>
        [DataTestMethod]
        [DataRow(false, 301)]
        [DataRow(true, 100)]
        [DataRow(false, 1)]
        [DataRow(true, 30)]

        public void IsEnginePowerCorrectTest(bool expectedResult, int enginePower)
        {
            Assert.AreEqual(expectedResult, enginePower.IsEnginePowerCorrect());
        }

        /// <summary>
        /// Тест проверяет корректность стоимость автомобиля.
        /// </summary>
        /// <param name="expectedResult">Ожидаемый результат проверки.</param>
        /// <param name="carCost">Стоимость автомобиля.</param>
        [DataTestMethod]
        [DataRow(false, 4999)]
        [DataRow(true, 700000)]
        [DataRow(false, 20000001)]
        [DataRow(true, 10000)]

        public void IsCarCostCorrectTest(bool expectedResult, int carCost)
        {
            Assert.AreEqual(expectedResult, carCost.IsCarCostCorrect());
        }

        /// <summary>
        /// Тест проверяет корректность роль пользователя.
        /// </summary>
        [TestMethod]
        public void IsRoleCorrectTest()
        {
            var role = "user";
            Assert.IsTrue(role.IsRoleCorrect());

            role = "administrator";
            Assert.IsTrue(role.IsRoleCorrect());

            role = "superadmin";
            Assert.IsFalse(role.IsRoleCorrect());
        }
    }
}
