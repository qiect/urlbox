using Haowen.BackgroundJobs;
using Haowen.Configurations;
using Haowen.EntityFrameworkCore;
using Haowen.Filters;
using Haowen.Middleware;
using Haowen.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Haowen.Web;

[DependsOn(
       typeof(AbpAspNetCoreMvcModule),
       typeof(AbpAutofacModule),
       typeof(HaowenHttpApiModule),
       typeof(HaowenSwaggerModule),
       typeof(HaowenEntityFrameworkCoreModule)
    //typeof(TemplateBackgroundJobsModule)
    )]
public class HaowenHttpApiHostingModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // 身份验证
        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,//是否验证颁发者
                       ValidateAudience = true,//是否验证访问群体
                       ValidateLifetime = true,//是否验证生存期
                       ClockSkew = TimeSpan.FromSeconds(30),//验证Token的时间偏移量
                       ValidateIssuerSigningKey = true,//是否验证安全密钥
                       ValidAudience = AppSettings.JWT.Domain,//访问群体
                       ValidIssuer = AppSettings.JWT.Domain,//颁发者
                       IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())//安全密钥
                   };
               });

        // 认证授权
        context.Services.AddAuthorization();

        // Http请求
        context.Services.AddHttpClient();

        //异常处理
        Configure<MvcOptions>(options =>
        {
            var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

            // 移除 AbpExceptionFilter
            options.Filters.Remove(filterMetadata);
            options.Filters.Add(typeof(HaowenExceptionFilter));
        });


        //路由规则配置
        context.Services.AddRouting(options =>
        {
            // 设置URL为小写
            options.LowercaseUrls = true;
            // 在生成的URL后面添加斜杠
            options.AppendTrailingSlash = true;
        });

        context.Services.AddCors(options =>
        {
            options.AddPolicy("any", builder =>
            {
                builder.WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS")
            //.AllowCredentials()//指定处理cookie
            .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); //允许任何来源的主机访问
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        // 环境变量，开发环境
        if (env.IsDevelopment())
        {
            // 生成异常页面
            app.UseDeveloperExceptionPage();
        }


        // 路由
        app.UseRouting();

        // 异常处理中间件
        app.UseMiddleware<ExceptionHandlerMiddleware>();

        // 身份验证
        app.UseAuthentication();

        // 认证授权
        app.UseAuthorization();

        //app.UseHsts();//使用HSTS的中间件，该中间件添加了严格传输安全头
        app.UseCors("any");//使用默认的跨域配置
        //app.UseHttpsRedirection();//HTTP请求转HTTPS

        // 路由映射
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
