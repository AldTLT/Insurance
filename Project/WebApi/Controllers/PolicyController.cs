using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Insurance.WCF;
using Insurance.BL.Models;
using System.Web.Http.Description;

namespace Insurance.WebApi.Controllers
{
    [Authorize]
    public class PolicyController : ApiController
    {
        private readonly IPolicyService _policyService;

        public PolicyController()
        {
            _policyService = new PolicyService();
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Запрос: получение коллекции Policy.
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(Policy))]
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

        // POST api/values
        public void Post([FromBody]string value)
        {
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
