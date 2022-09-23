using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace URLBox.EntityFrameworkCore.DbMigrations
{
    [DependsOn(
    typeof(URLBoxEntityFrameworkCoreModule)
    )]
    public class URLBoxEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<URLBoxDbContext>();
        }
    }
}