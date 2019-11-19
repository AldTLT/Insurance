using Insurance.BL.Models;

namespace Insurance.BL
{
    /// <summary>
    /// Класс представляет методы управления типа User.
    /// </summary>
    public class AccountManager
    {
        /// <summary>
        /// Экземпляр класса, реализующего интерфейс IAuthRepository.
        /// </summary>
        private readonly IAuthRepository _authRepository;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="authRepository">Репозиторий, реализующий интерфейс IAuthRepository.</param>
        public AccountManager(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        /// <summary>
        /// Метод возвращает результат авторизации пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя.</param>
        /// <param name="passwordHash">Хэш-код пароля.</param>
        /// <returns>true - если пользователь успешно авторизовался и формат e-mail валидный, иначе - false.</returns>
        public bool SignIn(string email, string passwordHash)
        {
            var lowerEmail = email.ToLower();
            return lowerEmail.IsEmailCorrect() ? _authRepository.SignIn(lowerEmail, passwordHash) : false;
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
        /// Метод возвращает Insurance.BL.Models.User по email.
        /// </summary>
        /// <param name="email">E-mail пользователя для идентификации.</param>
        /// <returns>Insurance.BL.Models.User соответствующий email если присутствует, иначе - null.</returns>
        public User GetUser(string email)
        {
            var lowerEmail = email.ToLower();
            return lowerEmail.IsEmailCorrect() ? _authRepository.GetUser(lowerEmail) : null;
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
            var lowerEmail = email.ToLower();
            return lowerEmail.IsEmailCorrect() ? _authRepository.ChangePassword(email, oldPasswordHash, newPasswordHash) : false;
        }
    }
}
