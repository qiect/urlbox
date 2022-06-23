using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.DependencyInjection;

namespace Haowen.Application.Caching
{
    public class CachingServiceBase : ITransientDependency
    {
        //属性注入
        public IDistributedCache Cache { get; set; }
    }
}
