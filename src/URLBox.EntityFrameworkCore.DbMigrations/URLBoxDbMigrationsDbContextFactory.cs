using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLBox.EntityFrameworkCore.DbMigrations
{
    public class URLBoxDbMigrationsDbContextFactory : IDesignTimeDbContextFactory<URLBoxDbMigrationsDbContext>
    {
        public URLBoxDbMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<URLBoxDbMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("MySql"), ServerVersion.Parse("8.0.27"));

            return new URLBoxDbMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
