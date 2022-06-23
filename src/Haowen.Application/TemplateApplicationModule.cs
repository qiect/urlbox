using Haowen.Application.Caching;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Haowen;

[DependsOn(
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(TemplateAppCachingModule)    
    )]
public class TemplateApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<TemplateApplicationModule>(validate: true);
            options.AddProfile<TemplateAutoMapperProfile>(validate: true);
        });
    }
}
