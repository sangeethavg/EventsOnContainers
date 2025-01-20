using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace OrderApi.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OrdersContext>
    {
        public OrdersContext CreateDbContext(string[] args)
        {
            // Build configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string
            var connectionString = configuration["ConnectionString"];

            // Build options
            var optionsBuilder = new DbContextOptionsBuilder<OrdersContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new OrdersContext(optionsBuilder.Options);
        }
    }
}
