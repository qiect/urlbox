using Volo.Abp.Modularity;

namespace Haowen;

[DependsOn(
    typeof(TemplateDomainSharedModule)
)]
public class TemplateApplicationContractsModule : AbpModule
{

}
