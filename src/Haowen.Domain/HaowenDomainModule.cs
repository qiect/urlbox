using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Haowen;

[DependsOn(
    typeof(HaowenDomainSharedModule),
    typeof(AbpIdentityDomainModule)
)]
public class HaowenDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}
