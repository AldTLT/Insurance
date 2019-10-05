using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Insurance.BL.Models;

namespace Insurance.BL
{
    public class AccountManager
    {
        private readonly IAuthRepository _authRepository;

        public AccountManager(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        /// <summary>
        /// Метод возвращает результат авторизации пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя.</param>
        /// <param name="passwordHash">Хэш-код пароля.</param>
        /// <returns>true - если пользователь успешно авторизовался, иначе - false.</returns>
        public bool SignIn(string email, string passwordHash)
        {
            return _authRepository.SignIn(email, passwordHash);
        }

        /// <summary>
        /// Метод возвращает результат добавления нового пользователя в систему.
        /// </summary>
        /// <param name="client">Insurance.BL.Models.Client для добавления в БД.</param>
        /// <returns>true, если пользователь успешно добавлен в систему, иначе - false.</returns>
        public bool Registration(User client)
        {
            return _authRepository.Registration(client);
        }

        /// <summary>
        /// Метод возвращает результат проверки ввода E-mail на корректность.
        /// </summary>
        /// <param name="mail">E-mail для проверки.</param>
        /// <returns>true, если e-mail в правильном формате, иначе - false.</returns>
        public bool IsEmailCorrect(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
