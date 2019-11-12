using Insurance.BL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainRepository
{
    /// <summary>
    /// Класс инициализации базы данных, если она не существует.
    /// </summary>
    public class InitializeDb : CreateDatabaseIfNotExists<DataContext>
    {
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
            var passwordHash = "ᘺ孁래㮲건Ǒ몒莵閟螺"; //пароль: mypassword
            var user = new User("vr0rtex@mail.ru", "Юрий Уливанов Геннадьевич", new DateTime(1984, 4, 13), new DateTime(2003, 01, 15), passwordHash);
            user.Role.Add("administrator");
            repository.Registration(user);
        }
    }
}
