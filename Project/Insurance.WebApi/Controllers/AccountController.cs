using Insurance.BL.Models;
using Insurance.WCF;
using NLog;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace Insurance.WebApi.Controllers
{
    /// <summary>
    /// Контроллер управления аккаунтом.
    /// </summary>
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        /// <summary>
        /// Сервис управления аккаунтом.
        /// </summary>
        private readonly IAuthService _authService;

        /// <summary>
        /// Экземпляр логгера.
        /// </summary>
        private Logger _logger;

        /// <summary>
        /// Конструктор контроллера.
        /// </summary>
        public AccountController()
        {
            _authService = new AuthService();
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Запрос получение User.
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(User))]
        [Authorize]
        [Route("User")]
        public IHttpActionResult GetUser()
        {
            //Логгирование: запрос на получение пользователя.
            _logger.Trace($"Запрос данных пользователя.");

            var email = string.Empty;
            try
            {
                email = Request
                    .Headers
                    .FirstOrDefault(e => e.Key.Equals("email"))
                    .Value
                    .FirstOrDefault();
            }
            catch
            {
                //Логгирование: ошибка получения email.
                _logger.Error($"Ошибка. Заголовок не содержит email.");

                return NotFound();
            }

            if (string.IsNullOrEmpty(email))
            {
                //Логгирование: e-mail пустой.
                _logger.Error($"E-mail пустой.");

                return NotFound();
            }

            var user = _authService.GetUser(email);

            if (user == null)
            {
                //Логгирование: пользователь не существует.
                _logger.Error($"Пользователь с адресом <{email}> не найден.");

                return NotFound();
            }

            //Логгирование: запрос выполнен.
            _logger.Trace($"Запрос получение данных пользователя <{email}> выполнен.");

            return Ok(user);
        }

        /// <summary>
        /// Запрос регистрация нового пользователя.
        /// </summary>
        /// <param name="model">Модель данных регистрации пользователя.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register(RegisterBindingModel model)
        {
            //Логгирование: запрос регистрации пользователя.
            _logger.Trace($"Запрос регистрации пользователя.");

            if (!ModelState.IsValid)
            {
                //Логгирование: ошибка модели данных.
                _logger.Error($"Модель данных регистрации пользователя не валидна.");

                return BadRequest(ModelState);
            }

            var hash = model.Password.GetHash();

            var registerResult = _authService.RegistrationAccount
                    (
                model.Email,
                model.Name,
                model.BirthDate,
                model.DriverLicenseDate,
                hash
                );

            if (!registerResult)
            {
                //Логгирование: ошибка регистрации пользователя.
                _logger.Error($"Ошибка регистрации пользователя <{model.Email}>.");

                return NotFound();
            }
            else
            {
                //Логгирование: запрос регистрации выполнен.
                _logger.Trace($"Запрос регистрации пользователя <{model.Email}> выполнен.");

                return Ok(registerResult);
            }
        }
    }
}
