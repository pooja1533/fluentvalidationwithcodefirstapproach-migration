using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fluent.Model
{
    public class DatabaseContext:DbContext
    {
        private readonly IConfiguration configuration;
        public DatabaseContext(IConfiguration _configuration)
        {
            configuration= _configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("default")); 
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
