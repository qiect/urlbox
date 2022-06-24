using Volo.Abp.Modularity;

namespace Haowen;

[DependsOn(
    typeof(HaowenDomainSharedModule)
)]
public class TemplateApplicationContractsModule : AbpModule
{

}
