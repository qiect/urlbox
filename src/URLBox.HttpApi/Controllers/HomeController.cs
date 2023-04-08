using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLBox.ToolKits.Base;
using Volo.Abp.AspNetCore.Mvc;

namespace URLBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_Admin)]
    public class HomeController : AbpController
    {
        /// <summary>
        /// 查询Article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("index")]
        public ServiceResult<string> Index(string access_token, string expires_in)
        {
            var cookies = HttpContext.Response.Cookies;
            return new ServiceResult<string>();
        }
    }
}
