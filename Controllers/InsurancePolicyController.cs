using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

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
        public IEnumerable<InsurancePolicy> Get()
        {
            using (InsurancePolicyContext dataBase = new InsurancePolicyContext())
            {
                return dataBase.InsurancePolicy.ToList();
            }          
        }

        [HttpPost]
        public IEnumerable<InsurancePolicy> Add(InsurancePolicy policy)
        {
            using (InsurancePolicyContext dataBase = new InsurancePolicyContext())
            {
                policy.ID = Guid.NewGuid().ToString();
                policy.dateOfCreation = DateTime.UtcNow;

                dataBase.InsurancePolicy.Add(policy);
                dataBase.InsurancePolicy.Add(policy);
                dataBase.SaveChanges();

                return dataBase.InsurancePolicy.ToList();
            }
        }

        [HttpPut]
        public IEnumerable<InsurancePolicy> Сhange(InsurancePolicy policy)
        {
            using (InsurancePolicyContext dataBase = new InsurancePolicyContext())
            {
                dataBase.Update(policy);
                dataBase.SaveChanges();

                return dataBase.InsurancePolicy.ToList();
            }
        }

        [HttpDelete("{ID}")]
        public IEnumerable<InsurancePolicy> Delete(string ID)
        {
            using (InsurancePolicyContext dataBase = new InsurancePolicyContext())
            {
                var InsurancePoliciesFromDelete = dataBase.InsurancePolicy.Where(val => val.ID == ID);

                foreach (var policy in InsurancePoliciesFromDelete)
                {
                    dataBase.InsurancePolicy.Remove(policy);
                }

                dataBase.SaveChanges();

                return dataBase.InsurancePolicy.ToList();
            }
        }
    }
}
