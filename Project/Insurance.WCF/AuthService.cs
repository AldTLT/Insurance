using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MainRepository;
using Insurance.BL;
using MainRepository.ModelsRepository;
using Insurance.BL.Models;
using Stub;

namespace Insurance.WCF
{
    /// <summary>
    /// Класс представляет сервисы аутентификации и авторизации пользователя.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly DataContext _context = new DataContext();
        private readonly IAuthRepository _authRepository;

        public AuthService()
        {
            _authRepository = new AuthRepository(_context);            
            //_authRepository = new StubAuthRepository();
        }

        public User GetUser(string email)
        {
            return _authRepository.GetUser(email);
        }

        /// <summary>
        /// Метод возвращает результат создания нового пользователя.
        /// </summary>
        /// <param name="mail">E-mail пользователя.</param>
        /// <param name="fullName">Полное имя пользователя.</param>
        /// <param name="birthDate">Дата рождения пользователя.</param>
        /// <param name="driverLicenseDate">Дата выдачи прав пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>true, если асккаунт успешно создан, иначе - false.</returns>
        public bool RegistrationAccount(string mail, string fullName, DateTime birthDate, DateTime driverLicenseDate, string passwordHash)
        {
            var accountManager = new AccountManager(_authRepository);
            var account = new User(mail, fullName, birthDate, driverLicenseDate, passwordHash);

            return accountManager.Registration(account);
        }

        /// <summary>
        /// Сервис возвращает результат авторизации пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя.</param>
        /// <param name="passwordHash">Пароль пользователя.</param>
        /// <returns>true, если пользователь успешно авторизован, иначе - false.</returns>
        public bool SignIn(string email, string passwordHash)
        {
            var accountManager = new AccountManager(_authRepository);

            return accountManager.SignIn(email, passwordHash);
        }
    }
}
