﻿using System;
using System.ServiceModel;
using Insurance.BL.Models;

namespace Insurance.WCF
{ 
    /// <summary>
    /// Интерфейс представляет методы управления аккаунтом.
    /// </summary>
    [ServiceContract]
    public interface IAuthService
    {
        /// <summary>
        /// Сервис возвращает результат авторизации пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>true, если пользователь успешно авторизован, иначе - false.</returns>
        [OperationContract]
        bool SignIn(string email, string password);

        /// <summary>
        /// Метод возвращает результат создания нового пользователя.
        /// </summary>
        /// <param name="mail">E-mail пользователя.</param>
        /// <param name="fullName">Полное имя пользователя.</param>
        /// <param name="birthDate">Дата рождения пользователя.</param>
        /// <param name="driverLicenseDate">Дата выдачи прав пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>true, если асккаунт успешно создан, иначе - false.</returns>
        [OperationContract]
        bool RegistrationAccount(string mail, string fullName, DateTime birthDate, DateTime driverLicenseDate, string password);

        /// <summary>
        /// Метод возвращает User по email.
        /// </summary>
        /// <param name="email">Email соответствующий типу User.</param>
        /// <returns>User, которому принадлежит email. Усли такого не существует, возвращается null.</returns>
        [OperationContract]
        User GetUser(string email);
    }
}
