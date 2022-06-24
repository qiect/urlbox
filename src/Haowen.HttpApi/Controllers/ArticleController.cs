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
    public class ArticleController : AbpController
    {
        private readonly IArticleService _ArticleService;

        public ArticleController(IArticleService ArticleService)
        {
            this._ArticleService = ArticleService;
        }

        /// <summary>
        /// 添加Article
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ServiceResult<string>> InsertArticleAsync([FromBody] ArticleDto dto)
        {
            return await _ArticleService.InsertArticleAsync(dto);
        }
        /// <summary>
        /// 删除Article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ServiceResult> DeleteArticleAsync([Required] Guid id)
        {
            return await _ArticleService.DeleteArticleAsync(id);
        }

        /// <summary>
        /// 更新Article
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ServiceResult<string>> UpdateArticleAsync([Required] Guid id, [FromBody] ArticleDto dto)
        {
            return await _ArticleService.UpdateArticleAsync(id, dto);
        }

        /// <summary>
        /// 查询Article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ServiceResult<ArticleDto>> GetArticleAsync([Required] Guid id)
        {
            return await _ArticleService.GetArticleAsync(id);
        }
    }
}
