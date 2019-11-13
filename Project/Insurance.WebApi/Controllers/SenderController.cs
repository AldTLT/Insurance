using Insurance.WCF;
using NLog;
using System.Linq;
using System.Web.Http;

namespace Insurance.WebApi.Controllers
{
    /// <summary>
    /// Контроллер отправки сообщения на почту.
    /// </summary>
    [RoutePrefix("api/Sender")]
    public class SenderController : ApiController
    {
        /// <summary>
        /// Сервис отправки сообщения на почту.
        /// </summary>
        private readonly IMailService _smtpService;

        /// <summary>
        /// Экземпляр логгера.
        /// </summary>
        private Logger _logger;

        public SenderController()
        {
            _smtpService = new MailService();
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Запрос отправки сообщения на почту.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("SendMail")]
        public IHttpActionResult SendMail()
        {
            //Логгирование: запрос отправки сообщения.
            _logger.Trace($"Запрос отправки сообщения.");

            //Получение email из headers запроса.
            var email = string.Empty;
            //Получение номера автомобиля из headers запроса.
            var carNumber = string.Empty;

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

            try
            { 
                carNumber = Request
                    .Headers
                    .FirstOrDefault(n => n.Key.Equals("carNumber"))
                    .Value
                    .FirstOrDefault();
            }
            catch
            {
                //Логгирование: ошибка получения номера автомобиля.
                _logger.Error($"Ошибка, заголовок не содержит carNumber.");

                return NotFound();
            }

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(carNumber))
            {
                //Логгирование: ошибка email или номер автомобиля не содержат значение.
                _logger.Error($"Ошибка, <{email}> или <{carNumber}> не содержит значение.");

                return NotFound();
            }

            _smtpService.SendPdf(carNumber, email);

            //Логгирование: запрос выполнен.
            _logger.Trace($"Запрос отправки сообщения пользователю <{email}> выполнен.");

            return Ok();
        }
    }
}
