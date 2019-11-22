using Insurance.BL.Models;
using MainRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MainRepository
{
    /// <summary>
    /// Класс инициализации базы данных, если она не существует.
    /// </summary>
    public class InitializeDb : CreateDatabaseIfNotExists<DataContext>
    {
        /// <summary>
        /// Роль пользователя - полный доступ.
        /// </summary>
        private const string administrator = "administrator";

        /// <summary>
        /// Роль пользователя - ограниченный доступ.
        /// </summary>
        private const string user = "user";

        /// <summary>
        /// Пароль.
        /// </summary>
        private const string password = "mypassword";

        /// <summary>
        /// E-mail пользователя.
        /// </summary>
        private const string email = "vr0rtex@mail.ru";

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        private const string name = "Уливанов Юрий Геннадьевич";

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        private readonly DateTime birthDate = new DateTime(1984, 4, 13);

        /// <summary>
        /// Дата выдачи водительских прав пользователя.
        /// </summary>
        private readonly DateTime driverLicenseDate = new DateTime(2003, 01, 15);

        /// <summary>
        /// Роль пользователя - полный доступ.
        /// </summary>
        private const string administratorRole = "administrator";

        /// <summary>
        /// Метод инициализации базы данных.
        /// </summary>
        /// <param name="context">Контекст подключения к базе данных.</param>
        public override void InitializeDatabase(DataContext context)
        {
            //Создание базы данных.
            base.InitializeDatabase(context);
                       
            //Создание роли пользователя.
            var userRole = new RoleModel() { RoleName = user };
            var administartorRole = new RoleModel() { RoleName = administrator };
            var roleList = new List<RoleModel>() { userRole, administartorRole };

            //Инициализация пользователя.           
            var clientModel = new ClientModel()
            {
                EMail = email,
                Name = name,
                BirthDate = birthDate,
                DriverLicenseDate = driverLicenseDate,
                PasswordHash = password.GetHashCode().ToString(),
                Roles = roleList
            };

            try
            {
                context.Client.Add(clientModel);
                context.SaveChanges();
            }
            catch
            {
                return;
            }
        }
    }
}
