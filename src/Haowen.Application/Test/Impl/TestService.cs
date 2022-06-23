using Haowen.Repositories;
using Haowen.ToolKits.Base;

namespace Haowen
{
    public class TestService : ServiceBase, ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            this._testRepository = testRepository;
        }

        public async Task<ServiceResult> DeleteTestAsync(Guid id)
        {
            var result = new ServiceResult();
            await _testRepository.DeleteAsync(id);
            return result;
        }

        public async Task<ServiceResult<TestDto>> GetTestAsync(Guid id)
        {
            var result = new ServiceResult<TestDto>();
            var entity = await _testRepository.GetAsync(id);
            if (entity == null)
            {
                result.IsFailed("Test不存在！");
            }
            else
            {
                var dto = ObjectMapper.Map<Test, TestDto>(entity);
                result.IsSuccess(dto);
            }
            return result;
        }

        public async Task<ServiceResult<string>> InsertTestAsync(TestDto dto)
        {
            var result = new ServiceResult<string>();
            var entity = ObjectMapper.Map<TestDto,Test>(dto); 
            var test = await _testRepository.InsertAsync(entity);
            if (test != null)
            {
                result.IsSuccess("添加成功！");
            }
            else
            {
                result.IsFailed("添加失败！");
            }
            return result;
        }

        public async Task<ServiceResult<string>> UpdateTestAsync(Guid id, TestDto dto)
        {
            var result = new ServiceResult<string>();
            var entity = await _testRepository.GetAsync(id);
            if (entity == null)
            {
                result.IsFailed("Test不存在！");
            }
            else
            {
                entity.Name = dto.Name;
                entity.Remark = dto.Remark;
                await _testRepository.UpdateAsync(entity);
                result.IsSuccess("更新成功！");
            }
            return result;
        }
    }
}
