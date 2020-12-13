using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Insurance_policy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsurancePolicyController : ControllerBase
    {

        private readonly ILogger<InsurancePolicyController> _logger;

        public InsurancePolicyController(ILogger<InsurancePolicyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<InsurancePolicy> GetPolicies()
        {
            return DataBaseManager.GetPoliciesFromDataBase();
        }

        [HttpPost]
        public void AddPolicy(InsurancePolicy policy)
        {
            DataBaseManager.AddPolicyToDataBase(policy);
        }

        [HttpPut]
        public void СhangePolicy(InsurancePolicy policy)
        {
            DataBaseManager.СhangePolicyInDataBase(policy);
        }

        [HttpDelete("{ID}")]
        public void DeletePolicy(string ID)
        {
            DataBaseManager.DeletePolicyDataBase(ID);
        }
    }
}
