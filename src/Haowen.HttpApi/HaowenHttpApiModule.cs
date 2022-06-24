using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Haowen;

[DependsOn(
    typeof(AbpIdentityHttpApiModule),
    typeof(HaowenApplicationModule)
    )]
public class HaowenHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
       
    }

}
