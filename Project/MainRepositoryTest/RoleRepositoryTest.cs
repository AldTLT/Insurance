using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainRepository;
using Insurance.BL.Models;
using MainRepository.Models;
using MainRepository.ModelsRepository;

namespace MainRepositoryTest
{
    [TestClass]
    public class RoleRepositoryTest
    {
        private readonly DataContext _dataContext = new DataContext();
        private RoleRepository _roleRepository;

        /// <summary>
        /// Инициализация данных перед тестами.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _roleRepository = new RoleRepository(_dataContext);
        }

        /// <summary>
        /// Тест метода RoleToRoleModel.
        /// </summary>
        [TestMethod]
        public void RoleToRoleModelTest()
        {
            var expectedRoleModel = new RoleModel() { RoleId = 1, RoleName = "user" };
            var role = new Role(1, "user");
            var roleModel = _roleRepository.RoleToRoleModel(role);

            Assert.AreEqual(expectedRoleModel, roleModel);
        }

        /// <summary>
        /// Тест метода RoleToRoleModel.
        /// </summary>
        [TestMethod]
        public void RoleModelToRoleTest()
        {
            var expectedRole = new Role(2, "administrator");
            var roleModel = new RoleModel() { RoleId = 2, RoleName = "administrator" };
            var role = _roleRepository.RoleModelToRole(roleModel);

            Assert.AreEqual(expectedRole, role);
        }
    }
}
