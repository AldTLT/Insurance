using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Insurance.WCF;

namespace Insurance.WebApi.Controllers
{
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

        // GET api/values/5
        public string GetPolicy()
        {
            var email = Request
                .Headers
                .FirstOrDefault(c => c.Key.Equals("email"))
                .Value
                .FirstOrDefault();

            var policyCollection = _policyService.GetPolicy(email);
            var result = string.Empty;

            foreach (var policy in policyCollection)
            {
                result += policy.ToString() + " ";
            }

            return result;
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
