using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainRepository;
using Insurance.BL;

namespace Insurance.Auth.Test
{
    [TestClass]
    public class PolicyManagerTest
    {
        [TestMethod]
        public void GetPolicyTest()
        {
            var repository = new PolicyRepository(new DataContext());
            var manager = new PolicyManager(repository);
        }
    }
}
