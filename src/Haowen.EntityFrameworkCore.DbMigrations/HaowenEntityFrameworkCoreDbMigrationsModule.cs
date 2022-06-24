using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Haowen.EntityFrameworkCore.DbMigrations
{
    [DependsOn(
    typeof(HaowenEntityFrameworkCoreModule)
    )]
    public class HaowenEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HaowenDbContext>();
        }
    }
}