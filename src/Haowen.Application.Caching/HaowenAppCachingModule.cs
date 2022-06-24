using Haowen.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Haowen.Application.Caching
{
    [DependsOn(
    typeof(AbpCachingModule),
    typeof(HaowenDomainModule)
    )]
    public class HaowenAppCachingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = AppSettings.Caching.RedisConnectionString;
                //options.InstanceName//Redis 实例名称
                //options.ConfigurationOptions//Redis 的配置属性
            });
        }
    }
}
