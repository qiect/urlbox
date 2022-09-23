using URLBox.Application.Caching;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace URLBox;

[DependsOn(
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(URLBoxAppCachingModule)    
    )]
public class URLBoxApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //context.Services.AddTransient<IArticleService,ArticleService>()

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<URLBoxApplicationModule>(validate: true);
            options.AddProfile<URLBoxAutoMapperProfile>(validate: true);
        });
    }
}
