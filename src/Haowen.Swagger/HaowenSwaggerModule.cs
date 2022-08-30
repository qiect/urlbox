using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Haowen.Swagger
{
    [DependsOn(typeof(HaowenDomainModule))]
    public class HaowenSwaggerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSwagger();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.GetApplicationBuilder().UseSwagger(
                c =>
                {
                    c.PreSerializeFilters.Add((swagger, httpReq) =>
                    {
                        //根据访问地址，设置swagger服务路径
                        swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}/{httpReq.Headers["X-Forwarded-Prefix"]}" } };
                    });
                }).UseSwaggerUI();
        }
    }
}