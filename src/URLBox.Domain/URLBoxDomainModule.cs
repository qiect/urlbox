using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace URLBox;

[DependsOn(
    typeof(URLBoxDomainSharedModule),
    typeof(AbpIdentityDomainModule)
)]
public class URLBoxDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}
