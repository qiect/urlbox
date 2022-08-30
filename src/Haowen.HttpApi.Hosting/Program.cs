using Haowen.ToolKits.Log4Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Haowen.Web;

public class Program
{
    public async static Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseLog4Net().UseAutofac();
        builder.WebHost.UseUrls("http://*:5000");
        await builder.AddApplicationAsync<HaowenHttpApiHostingModule>();
        var app = builder.Build();
        await app.InitializeApplicationAsync();
        await app.RunAsync();

    }
}
