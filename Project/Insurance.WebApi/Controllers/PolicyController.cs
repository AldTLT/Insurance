using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Insurance.WCF;
using Insurance.BL.Models;
using System.Web.Http.Description;
using WebApi.Models;

namespace Insurance.WebApi.Controllers
{
    [Authorize]
    public class PolicyController : ApiController
    {
        private readonly IPolicyService _policyService;
        private readonly IAuthService _authService;

        public PolicyController()
        {
            _policyService = new PolicyService();
            _authService = new AuthService();
        }

        /// <summary>
        /// Запрос: получение коллекции Policy.
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(Policy))]
        [Authorize]
        public IHttpActionResult GetPolicy()
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

            var policyCollection = _policyService.GetPolicy(email);

            if (policyCollection.Count() == 0)
                return NotFound();

            return Ok(policyCollection);
        }

        // Регистрация нового полиса.
        [Authorize]
        public IHttpActionResult PolicyRegister(PolicyRegistrationBindingModel model)
        {
            if (!ModelState.IsValid)
            {
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
                return NotFound();
            }

                var registerResult = _policyService.PolicyRegistration(
                email,
                model.CarCost,
                model.CarNumber,
                model.CarModel,
                model.ManufacturedYear,
                model.EnginePower
                );

            if (!registerResult)
            {
                return NotFound();
            }

            return Ok();
        }

        /// <summary>
        /// Получение стоимости полиса.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        public IHttpActionResult GetPolicyCost(PolicyRegistrationBindingModel model)
        {
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

                var user = _authService.GetUser(email);
                birthDate = user.BirthDate;
                driverLicenseDate = user.DriverLicenseDate;


                var policyCost = _policyService.PolicyCalculate(
                    email,
                    model.CarCost,
                    model.ManufacturedYear,
                    driverLicenseDate,
                    birthDate,
                    model.EnginePower);

                return Ok(policyCost);
            }
            catch
            {
                return NotFound();
            }
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
