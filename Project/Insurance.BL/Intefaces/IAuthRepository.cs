﻿using Insurance.BL.Models;

namespace Insurance.BL
{
    /// <summary>
    /// Интерфейс представляет методы управления классом авторизации.
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Метод возвращает результат авторизации пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя.</param>
        /// <param name="passwordHash">Хэш-код пароля.</param>
        /// <returns>true - если пользователь успешно авторизовался, иначе - false.</returns>
        bool SignIn(string email, string passwordHash);

        /// <summary>
        /// Метод возвращает результат авторизации нового клиента.
        /// </summary>
        /// <param name="client">Insurance.BL.Models.Client для автрозизации.</param>
        /// <returns>true, если новый клиент успешно авторизован, иначе - false.</returns>
        bool Registration(User client);

        /// <summary>
        /// Метод возвращает Insurance.BL.Models.User по email.
        /// </summary>
        /// <param name="mail">E-mail пользователя для идентификации.</param>
        /// <returns>Insurance.BL.Models.User соответствующий email если присутствует, иначе - null.</returns>
        User GetUser(string mail);

        /// <summary>
        /// Метод возвращает результат смены пароля.
        /// </summary>
        /// <param name="email">E-mail пользователя для смены пароля.</param>
        /// <param name="oldPasswordHash">Старый хэш пароля.</param>
        /// <param name="newPasswordHash">Новый хэш пароля.</param>
        /// <returns>true, если пароль сменен успешно, иначе - false.</returns>
        bool ChangePassword(string email, string oldPasswordHash, string newPasswordHash);
    }
}
