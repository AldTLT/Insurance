using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Insurance.WCF;
using Insurance.BL.Models;
using System.Web.Http.Description;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Insurance.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IAuthService _authService;

        public UserController()
        {
            _authService = new AuthService();
        }

        /// <summary>
        /// Запрос получение User.
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser()
        {
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
                return NotFound();
            }
            if (string.IsNullOrEmpty(email))
                return NotFound();

            var user = _authService.GetUser(email);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Запрос: регистрация нового пользоваеля.
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[ResponseType(typeof(User))]
        //public IHttpActionResult RegistrationPost()
        //{
        //    var email = string.Empty;
        //    var name = string.Empty;
        //    DateTime birthDate;
        //    DateTime driverLicenseDate;
        //    var password = string.Empty;

        //    try
        //    {
        //        email = Request
        //            .Headers
        //            .FirstOrDefault(e => e.Key.Equals("email"))
        //            .Value
        //            .FirstOrDefault();

        //        name = Request
        //            .Headers
        //            .FirstOrDefault(e => e.Key.Equals("name"))
        //            .Value
        //            .FirstOrDefault();

        //        var birthDateString = Request.Headers.FirstOrDefault(e => e.Key.Equals("birthDate")).Value.FirstOrDefault();
        //        DateTime.TryParse(birthDateString, out birthDate);

        //        var driverLicenseDateString = Request.Headers.FirstOrDefault(e => e.Key.Equals("driverLicenseDate")).Value.FirstOrDefault();
        //        DateTime.TryParse(driverLicenseDateString, out driverLicenseDate);

        //        password = Request.Headers.FirstOrDefault(e => e.Key.Equals("password")).Value.FirstOrDefault();
        //    }
        //    catch
        //    {
        //        return NotFound();
        //    }

        //    var registrationResult = _authService.RegistrationAccount(email, name, birthDate, driverLicenseDate, password);

        //    return Ok(registrationResult);
        //}
    }
}
