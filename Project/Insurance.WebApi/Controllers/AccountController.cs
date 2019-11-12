﻿using Insurance.BL.Models;
using Insurance.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace Insurance.WebApi.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IAuthService _authService;

        public AccountController()
        {
            _authService = new AuthService();
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
        /// Регистрация нового пользователя.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = false;

            //try
            //{
                var hash = model.Password.GetHash();

                registerResult = _authService.RegistrationAccount
                    (
                    model.Email,
                    model.Name,
                    model.BirthDate,
                    model.DriverLicenseDate,
                    hash
                    );
            //}
            //catch
            //{
            //    registerResult = false;
            //}

            if (!registerResult)
            {
                return NotFound();
            }

            return Ok(registerResult);
        }
    }
}
