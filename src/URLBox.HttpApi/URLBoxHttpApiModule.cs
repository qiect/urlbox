using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace URLBox;

[DependsOn(
    typeof(AbpIdentityHttpApiModule),
    typeof(URLBoxApplicationModule)
    )]
public class URLBoxHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
       
    }

}
