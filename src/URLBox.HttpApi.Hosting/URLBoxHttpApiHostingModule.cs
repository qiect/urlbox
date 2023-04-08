using URLBox.BackgroundJobs;
using URLBox.Configurations;
using URLBox.EntityFrameworkCore;
using URLBox.Filters;
using URLBox.Middleware;
using URLBox.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.QQ;
using Microsoft.AspNetCore.Authentication;

namespace URLBox.Web;

[DependsOn(
       typeof(AbpAspNetCoreMvcModule),
       typeof(AbpAutofacModule),
       typeof(URLBoxHttpApiModule),
       typeof(URLBoxSwaggerModule),
       typeof(URLBoxEntityFrameworkCoreModule)
    )]
public class URLBoxHttpApiHostingModule : AbpModule
{
    private const string DefaultCorsPolicyName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
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
            options.Filters.Add(typeof(URLBoxExceptionFilter));
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
            options.AddPolicy(DefaultCorsPolicyName, builder =>
            {
                builder
                    .WithOrigins(
                        AppSettings.App.CorsOrigins
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        //身份认证
        context.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    //这里填写一些配置信息，默认即可
                })    //添加Cookie认证
                .AddQQ(qqOptions =>
                {
                    qqOptions.AppId = AppSettings.Authentication.QQ.AppId;    //QQ互联申请的AppId
                    qqOptions.AppKey = AppSettings.Authentication.QQ.AppKey;    //QQ互联申请的AppKey
                    qqOptions.CallbackPath = "/home/index";    //QQ互联回调地址
                                                               //自定义认证声明
                    qqOptions.ClaimActions.MapJsonKey(MyClaimTypes.QQOpenId, "openid");
                    qqOptions.ClaimActions.MapJsonKey(MyClaimTypes.QQName, "nickname");
                    qqOptions.ClaimActions.MapJsonKey(MyClaimTypes.QQFigure, "figureurl_qq_1");
                    qqOptions.ClaimActions.MapJsonKey(MyClaimTypes.QQGender, "gender");
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
        app.UseCors(DefaultCorsPolicyName);//使用默认的跨域配置
        //app.UseHttpsRedirection();//HTTP请求转HTTPS

        // 路由映射
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
