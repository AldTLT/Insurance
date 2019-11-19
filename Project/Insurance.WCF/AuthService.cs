using System;
using MainRepository;
using Insurance.BL;
using Insurance.BL.Models;
using Stub;

namespace Insurance.WCF
{
    /// <summary>
    /// Класс представляет сервисы аутентификации и авторизации пользователя.
    /// </summary>
    public class AuthService : IAuthService
    {
        /// <summary>
        /// Контекст соединения БД.
        /// </summary>
        private readonly DataContext _context = new DataContext();

        /// <summary>
        /// Экземпляр репозитория управления аккаунтом.
        /// </summary>
        private readonly IAuthRepository _authRepository;

        /// <summary>
        /// Конструктор сервиса управления аккаунтом.
        /// </summary>
        public AuthService()
        {
            _authRepository = new AuthRepository(_context);
            //_authRepository = new StubAuthRepository();
        }

        /// <summary>
        /// Метод возвращает Insurance.BL.Models.User по email.
        /// </summary>
        /// <param name="mail">E-mail пользователя для идентификации.</param>
        /// <returns>Insurance.BL.Models.User соответствующий email если присутствует, иначе - null.</returns>
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

        /// <summary>
        /// Метод возвращает результат смены пароля.
        /// </summary>
        /// <param name="email">E-mail пользователя для смены пароля.</param>
        /// <param name="oldPasswordHash">Старый хэш пароля.</param>
        /// <param name="newPasswordHash">Новый хэш пароля.</param>
        /// <returns>true, если пароль сменен успешно, иначе - false.</returns>
        public bool ChangePassword(string email, string oldPasswordHash, string newPasswordHash)
        {
            return _authRepository.ChangePassword(email, oldPasswordHash, newPasswordHash);
        }
    }
}
