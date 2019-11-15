using System;
using System.Linq;
using System.Web.Http;
using Insurance.WCF;
using Insurance.BL.Models;
using System.Web.Http.Description;
using WebApi.Models;
using NLog;

namespace Insurance.WebApi.Controllers
{
    /// <summary>
    /// Контроллер управления полисом.
    /// </summary>
    [RoutePrefix("api/Policy")]
    public class PolicyController : ApiController
    {
        /// <summary>
        /// Сервис управления полисом.
        /// </summary>
        private readonly IPolicyService _policyService;

        /// <summary>
        /// Сервис управления аккаунтом.
        /// </summary>
        private readonly IAuthService _authService;

        /// <summary>
        /// Экземпляр логгера.
        /// </summary>
        private Logger _logger;

        public PolicyController()
        {
            _policyService = new PolicyService();
            _authService = new AuthService();
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Запрос получение коллекции полисов.
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(Policy))]
        [Authorize]
        [HttpGet]
        [Route("Policy")]
        public IHttpActionResult GetPolicy()
        {
            //Логгирование: запрос на получение полисов.
            _logger.Trace($"Запрос полисов пользователя.");

            //Получение email из headers запроса.
            var email = string.Empty;

            try
            {
                email = Request
                    .Headers
                    .FirstOrDefault(c => c.Key.Equals("email"))
                    .Value
                    .FirstOrDefault();
            }
            catch
            {
                //Логгирование: ошибка получения email.
                _logger.Error($"Ошибка, заголовок не содержит email.");

                return NotFound();
            }

            if (string.IsNullOrEmpty(email))
            {
                //Логгирование: e-mail пустой.
                _logger.Error($"E-mail пустой.");

                return NotFound();
            }

            var policyCollection = _policyService.GetPolicy(email);

            if (policyCollection.Count() == 0)
            {
                //Логгирование: полисы отсутствуют.
                _logger.Trace($"Полисы пользователя с адресом <{email}> не найдены.");

                return NotFound();
            }

            //Логгирование: запрос выполнен.
            _logger.Trace(
                $"Запрос на получение полисов пользователя <{email}> выполнен. " +
                $"Найдено полисов: <{policyCollection.Count}>."
                );

            return Ok(policyCollection);
        }

        /// <summary>
        /// Запрос регистрация нового полиса.
        /// </summary>
        /// <param name="model">Модель данных регистрации полиса.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("PolicyRegister")]
        public IHttpActionResult PolicyRegister(PolicyRegistrationBindingModel model)
        {
            //Логгирование: запрос регистрации полиса.
            _logger.Trace($"Запрос регистрации полиса.");

            if (!ModelState.IsValid)
            {
                //Логгирование: ошибка модели данных.
                _logger.Error($"Модель данных регистрации полиса не валидна.");

                return BadRequest(ModelState);
            }

            var email = string.Empty;

            try
            {
                email = Request
                    .Headers
                    .FirstOrDefault(c => c.Key.Equals("email"))
                    .Value
                    .FirstOrDefault();
            }
            catch
            {
                //Логгирование: ошибка получения email.
                _logger.Error($"Ошибка, заголовок не содержит email.");

                return NotFound();
            }

            var policyNumber = _policyService.PolicyRegistration(
                email,
                model.CarCost,
                model.CarNumber,
                model.CarModel,
                model.ManufacturedYear,
                model.EnginePower
                );

            if (string.IsNullOrEmpty(policyNumber))
            {
                //Логгирование: ошибка регистрации полиса.
                _logger.Error($"Ошибка регистрации полиса на автомобиль <{model.CarNumber}>.");

                return NotFound();
            }
            else
            {
                //Логгирование: запрос регистрации выполнен.
                _logger.Trace($"Запрос регистрации полиса на автомобиль <{model.CarNumber}> выполнен.");

                return Ok(policyNumber);
            }
        }

        /// <summary>
        /// Запрос получение стоимости полиса.
        /// </summary>
        /// <param name="model">Модель данных регистрации полиса.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("PolicyCost")]
        public IHttpActionResult PolicyCost(PolicyRegistrationBindingModel model)
        {
            //Логгирование: запрос рассчета полиса.
            _logger.Trace($"Запрос рассчета полиса.");

            DateTime birthDate;
            DateTime driverLicenseDate;
            var email = string.Empty;

            try
            {
                email = Request
                    .Headers
                    .FirstOrDefault(c => c.Key.Equals("email"))
                    .Value
                    .FirstOrDefault();
            }
            catch
            {
                //Логгирование: ошибка получения email.
                _logger.Error($"Ошибка, заголовок не содержит email.");

                return NotFound();
            }

            var user = _authService.GetUser(email);

            if (user == null)
            {
                //Логгирование: пустой пользователь.
                _logger.Error($"Ошибка пользователь <{email}> пустой.");

                return NotFound();
            }

            if (user.BirthDate == null || user.DriverLicenseDate == null)
            {
                //Логгирование: ошибка даты.
                _logger.Error(
                    $"Ошибка дата рождения <{user.BirthDate}>, " +
                    $"или дата выдачи прав <{user.DriverLicenseDate}> " +
                    $"пользователя <{email}> некорректна.");
            }

            birthDate = user.BirthDate;
            driverLicenseDate = user.DriverLicenseDate;

            var policyCost = _policyService.PolicyCalculate(
                email,
                model.CarCost,
                model.ManufacturedYear,
                driverLicenseDate,
                birthDate,
                model.EnginePower);

            //Логгирование: запрос регистрации выполнен.
            _logger.Trace(
                $"Запрос регистрации полиса на автомобиль <{model.CarNumber}> выполнен." +
                $" Стоимость полиса <{policyCost}> рублей.");

            return Ok(policyCost);
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
