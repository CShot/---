using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Insurance_policy
{
    class InsurancePolicyContext : DbContext
    {       
        public InsurancePolicyContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("InsurancePolicyContext");

            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<InsurancePolicy> InsurancePolicy { get; set; }

    }
}
