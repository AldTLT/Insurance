using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Insurance.WebApi;
using Insurance.WebApi.Controllers;
using Insurance.WCF;

namespace Insurance.WebApi.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        private IPolicyService _policyService;

        [TestInitialize]
        private void Initialize()
        {
            _policyService = new PolicyService();
        }

        [TestMethod]
        public void Get()
        {
            // Упорядочение
            PolicyController controller = new PolicyController(_policyService);

            // Действие
            IEnumerable<string> result = controller.Get();

            // Утверждение
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Упорядочение
            PolicyController controller = new PolicyController(_policyService);

            // Действие
            string result = controller.Get(5);

            // Утверждение
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Упорядочение
            PolicyController controller = new PolicyController(_policyService);

            // Действие
            controller.Post("value");

            // Утверждение
        }

        [TestMethod]
        public void Put()
        {
            // Упорядочение
            PolicyController controller = new PolicyController(_policyService);

            // Действие
            controller.Put(5, "value");

            // Утверждение
        }

        [TestMethod]
        public void Delete()
        {
            // Упорядочение
            PolicyController controller = new PolicyController(_policyService);

            // Действие
            controller.Delete(5);

            // Утверждение
        }
    }
}
