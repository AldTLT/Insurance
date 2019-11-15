using Insurance.BL.Models;
using System;
using System.Data.Entity;

namespace MainRepository
{
    /// <summary>
    /// Класс инициализации базы данных, если она не существует.
    /// </summary>
    public class InitializeDb : CreateDatabaseIfNotExists<DataContext>
    {
        /// <summary>
        /// Хэш пароля.
        /// </summary>
        private const string passwordHash = "ᘺ孁래㮲건Ǒ몒莵閟螺"; //пароль: mypassword

        /// <summary>
        /// E-mail пользователя.
        /// </summary>
        private const string email = "vr0rtex@mail.ru";

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        private const string name = "Юрий Уливанов Геннадьевич";

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
            AuthRepository repository = new AuthRepository(context);

            //Инициализация пользователя.           
            var user = new User(
                email, 
                name, 
                birthDate, 
                driverLicenseDate,
                passwordHash
                );

            user.Role.Add(administratorRole);

            repository.Registration(user);
        }
    }
}
