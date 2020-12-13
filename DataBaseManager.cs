using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance_policy
{
    public static class DataBaseManager
    {
        public static IEnumerable<InsurancePolicy> GetPoliciesFromDataBase()
        {
            using (InsurancePolicyContext dataBase = new InsurancePolicyContext())
            {
                return dataBase.InsurancePolicy.ToList();
            }
        }
        public static void AddPolicyToDataBase(InsurancePolicy policy)
        {
            using (InsurancePolicyContext dataBase = new InsurancePolicyContext())
            {
                policy.ID = Guid.NewGuid().ToString();
                policy.dateOfCreation = DateTime.UtcNow;

                dataBase.InsurancePolicy.Add(policy);
                dataBase.InsurancePolicy.Add(policy);
                dataBase.SaveChanges();
            }
        }

        public static void СhangePolicyInDataBase(InsurancePolicy policy)
        {
            using (InsurancePolicyContext dataBase = new InsurancePolicyContext())
            {
                dataBase.Update(policy);
                dataBase.SaveChanges();
            }
        }

        public static void DeletePolicyDataBase(string ID)
        {
            using (InsurancePolicyContext dataBase = new InsurancePolicyContext())
            {
                var InsurancePoliciesFromDelete = dataBase.InsurancePolicy.Where(val => val.ID == ID);

                foreach (var policy in InsurancePoliciesFromDelete)
                {
                    dataBase.InsurancePolicy.Remove(policy);
                }

                dataBase.SaveChanges();

            }
        }
    }
}
