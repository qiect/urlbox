using Volo.Abp.Modularity;

namespace URLBox;

[DependsOn(
    typeof(URLBoxDomainSharedModule)
)]
public class TemplateApplicationContractsModule : AbpModule
{

}
