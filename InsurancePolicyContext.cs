using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Insurance_policy
{
    class InsurancePolicyContext : DbContext
    {
        public DbSet<InsurancePolicy> InsurancePolicy { get; set; }
        public InsurancePolicyContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=InsurancePolicy;Trusted_Connection=True;");
        }
    }
}
