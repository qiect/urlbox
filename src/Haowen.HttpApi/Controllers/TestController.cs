using Haowen.ToolKits.Base;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class TestController : AbpController
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            this._testService = testService;
        }

        /// <summary>
        /// 添加Test
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ServiceResult<string>> InsertTestAsync([FromBody] TestDto dto)
        {
            return await _testService.InsertTestAsync(dto);
        }
        /// <summary>
        /// 删除Test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ServiceResult> DeleteTestAsync([Required] Guid id)
        {
            return await _testService.DeleteTestAsync(id);
        }

        /// <summary>
        /// 更新Test
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ServiceResult<string>> UpdateTestAsync([Required] Guid id, [FromBody] TestDto dto)
        {
            return await _testService.UpdateTestAsync(id, dto);
        }

        /// <summary>
        /// 查询Test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ServiceResult<TestDto>> GetTestAsync([Required] Guid id)
        {
            return await _testService.GetTestAsync(id);
        }
    }
}
