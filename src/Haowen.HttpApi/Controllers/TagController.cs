using Haowen.ToolKits.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Haowen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_Admin)]
    //[Authorize]
    public class TagController : AbpController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            this._tagService = tagService;
        }

        /// <summary>
        /// 获取所有标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ServiceResult<string>> GetArticleAsync()
        {
            return await _tagService.GetTagAsync();
        }
    }
}
