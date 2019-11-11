using System;
using Insurance.BL;
using Insurance.BL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Insurance.Auth.Test
{
    [TestClass]
    public class EmailSenderTest
    {
        [TestMethod]
        public void SendEmailTest()
        {
            var user = new User(
                "vr0rtex@mail.ru",
                "Vasily Pupkin",
                new DateTime(1980, 10, 13),
                new DateTime(2010, 02, 05),
                "qwerty123");

            var carVesta = new Car("777TEST163RU", "Vesta", 2018, 750000, 104);
            var ratioVesta = new Ratio(1.2, 1.1, 0.8, 1.0);

            var policy = new Policy(5000, "vr0rtex@mail.ru", DateTime.Today, carVesta, ratioVesta);
            policy.PolicyId = new Guid("12345678-1234-5678-9012-123456789012");

            user.Role.Add("admin");

            var sender = new EmailSender();
            sender.SendMail(user, policy);

            Assert.IsTrue(true);
        }
    }
}
