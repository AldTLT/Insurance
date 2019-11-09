using Insurance.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Insurance.WebApi.Controllers
{
    [RoutePrefix("api/Sender")]
    public class SenderController : ApiController
    {
        private readonly ISmtpService _smtpService;

        public SenderController()
        {
            _smtpService = new SmtpService();
        }

        /// <summary>
        /// Метод отсылает сообщение на почту.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("SendMail")]
        public IHttpActionResult SendMail()
        {
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
                return NotFound();
            }

            if (string.IsNullOrEmpty(email))
                return NotFound();

            _smtpService.SendPdf(email);

            return Ok();
        }
    }
}
