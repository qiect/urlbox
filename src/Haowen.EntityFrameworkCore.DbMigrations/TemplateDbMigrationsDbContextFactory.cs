using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haowen.EntityFrameworkCore.DbMigrations
{
    public class TemplateDbMigrationsDbContextFactory : IDesignTimeDbContextFactory<TemplateDbMigrationsDbContext>
    {
        public TemplateDbMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<TemplateDbMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("MySql"), ServerVersion.Parse("8.0.27"));

            return new TemplateDbMigrationsDbContext(builder.Options);
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
