using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BL;
using Insurance.BL.Models;
using MainRepository.Models;

namespace MainRepository
{
    public class AuthRepository : IAuthRepository
    {
        /// <summary>
        /// Контекст для подключения к модели EDM.
        /// </summary>
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод возвращает Insurance.BL.Models.User по email.
        /// </summary>
        /// <param name="email">E-mail пользователя для идентификации.</param>
        /// <returns>Insurance.BL.Models.User соответствующий email если присутствует, иначе - null.</returns>
        public User GetUser(string email)
        {
            ClientModel client;

            var clientList = _context.Client.ToList();
                client = _context.Client.FirstOrDefault(c => c.EMail.Equals(email));

            if (client == null)
                return null;

            var user = ClientModelToUser(client);
            return user;            
        }

        /// <summary>
        /// Метод возвращает результат добавления нового пользователя в БД.
        /// </summary>
        /// <param name="user">Insurance.BL.Models.User для добавления в БД.</param>
        /// <returns>true, если пользователь успешно добавлен в БД, иначе - false.</returns>
        public bool Registration(User user)
        {
            if (IsMailExist(user.EMail))
            {
                return false;
            }

            var client = UserToClientModel(user);

            try
            {
                _context.Client.Add(client);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Метод возвращает результат авторизации пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя.</param>
        /// <param name="passwordHash">Хэш-код пароля.</param>
        /// <returns>true - если пользователь успешно авторизовался, иначе - false.</returns>
        public bool SignIn(string email, string passwordHash)
        {
            try
            {
                return _context.Client.Any(c => c.EMail.Equals(email) && c.PasswordHash.Equals(passwordHash));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод возвращает результат проверки существует ли e-mail в БД.
        /// </summary>
        /// <param name="mail">E-mail Для проверки.</param>
        /// <returns>true, если e-mail уже есть в БД, иначе - false.</returns>
        private bool IsMailExist(string mail)
        {
            try
            {
                return _context.Client.Any(c => c.EMail.Equals(mail));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод возвращает сущность ClientModel, полученную из Insurance.BL.Models.User.
        /// </summary>
        /// <param name="user">Исходный Insurance.BL.Models.User.</param>
        /// <returns>ClientModel с данными из Insurance.BL.Models.User.</returns>
        public ClientModel UserToClientModel(User user)
        {
            if (user == null)
                return null;

            var client = new ClientModel()
            {
                EMail = user.EMail,
                Name = user.Name,
                BirthDate = user.BirthDate,
                DriverLicenseDate = user.DriverLicenseDate,
                PasswordHash = user.PasswordHash
            };

            return client;
        }

        /// <summary>
        /// Метод возвращает Insurance.BL.Models.User, полученную из ClientModel.
        /// </summary>
        /// <param name="client">Исходный ClientModel.</param>
        /// <returns>Insurance.BL.Models.User с данными из ClientModel.</returns>
        public User ClientModelToUser(ClientModel client)
        {

            if (client == null)
                return null;

            var user = new User(
                client.EMail,
                client.Name,
                client.BirthDate,
                client.DriverLicenseDate,
                client.PasswordHash
                );

            return user;
        }


    }
}
