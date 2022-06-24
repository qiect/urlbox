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
    public class HaowenDbMigrationsDbContextFactory : IDesignTimeDbContextFactory<HaowenDbMigrationsDbContext>
    {
        public HaowenDbMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<HaowenDbMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("MySql"), ServerVersion.Parse("8.0.27"));

            return new HaowenDbMigrationsDbContext(builder.Options);
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
