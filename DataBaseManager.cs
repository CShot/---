using System;
using System.Collections.Generic;
using System.Linq;

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
                policy.Id = Guid.NewGuid().ToString();
                policy.DateOfCreation = DateTime.UtcNow;

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

        public static void DeletePolicyDataBase(string id)
        {
            using (InsurancePolicyContext dataBase = new InsurancePolicyContext())
            {
                var InsurancePoliciesFromDelete = dataBase.InsurancePolicy.Where(val => val.Id == id);

                foreach (var policy in InsurancePoliciesFromDelete)
                {
                    dataBase.InsurancePolicy.Remove(policy);
                }

                dataBase.SaveChanges();

            }
        }
    }
}
