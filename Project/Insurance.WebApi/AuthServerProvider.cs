using Insurance.WCF;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using NLog;

namespace Insurance.WebApi
{
    /// <summary>
    /// Класс представляет провайдер авторизации пользователя.
    /// </summary>
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// Сервис авторизации пользователя.
        /// </summary>
        private readonly IAuthService _authService;

        /// <summary>
        /// Конструктор класса провайдера авторизации.
        /// </summary>
        public AuthorizationServerProvider()
        {
            _authService = new AuthService();
        }

        /// <summary>
        /// Метод проверяет источник запроса и валидирует данные запроса.
        /// </summary>
        /// <param name="context">Контекст, содержащий данные и результаты.</param>
        /// <returns>Task to enable asynchronous execution</returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        /// <summary>
        /// Метод авторизации пользователя. Вызывается при запросе токена grant_type=password.
        /// </summary>
        /// <param name="context">Контекст, содержащий данные и результаты.</param>
        /// <returns>Task to enable asynchronous execution</returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Создание экземпляра логгера.
            Logger logger = LogManager.GetCurrentClassLogger();
            //Логгирование: запрос авторизации.
            logger.Trace($"Авторизация <{context.UserName}>");

            //Получить пользователя по email (UserName на самом деле - email).
            var user = _authService.GetUser(context.UserName);
{
                //Если пользователь с данным email не найден.
                if (user == null)
                {
                    context.SetError("invalid_grant", "E-mail не существует");
                    //Логгирование: неверный e-mail.
                    logger.Error($"Неверный Email <{context.UserName}>");
                    return;
                }

                //Вычисление хэша пароля.
                var hash = context.Password.GetHash();

                //Если пароль пользователя не совпадает с введеным паролем.
                if (!user.PasswordHash.Equals(hash))
                {
                    context.SetError("invalid_grant", "Пароль пользователя неверный");
                    //Логгирование: неверный пароль.
                    logger.Error($"Неверный пароль пользователя <{context.UserName}>");
                    return;
                }

                //Создание утверждений. 
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Email, user.EMail));

                var claimList = new List<Claim>();
                foreach(var role in user.Role)
                {
                    claimList.Add(new Claim(ClaimTypes.Role, role));
                }

                identity.AddClaims(claimList);
                context.Validated(identity);

                //Логгирование: успешная авторизация.
                logger.Trace($"Пользователь <{context.UserName}> авторизован");
            }
        }
    }
}