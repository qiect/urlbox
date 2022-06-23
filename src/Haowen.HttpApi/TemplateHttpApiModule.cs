using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Haowen;

[DependsOn(
    typeof(AbpIdentityHttpApiModule),
    typeof(TemplateApplicationModule)
    )]
public class TemplateHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
       
    }

}
