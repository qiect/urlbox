using Haowen.Repositories;
using Haowen.ToolKits.Base;

namespace Haowen
{
    public class AiticleService : ServiceBase, IArticleService
    {
        private readonly IArticleRepository _testRepository;

        public AiticleService(IArticleRepository testRepository)
        {
            this._testRepository = testRepository;
        }

        public async Task<ServiceResult> DeleteTestAsync(Guid id)
        {
            var result = new ServiceResult();
            await _testRepository.DeleteAsync(id);
            return result;
        }

        public async Task<ServiceResult<ArticleDto>> GetTestAsync(Guid id)
        {
            var result = new ServiceResult<ArticleDto>();
            var entity = await _testRepository.GetAsync(id);
            if (entity == null)
            {
                result.IsFailed("Test不存在！");
            }
            else
            {
                var dto = ObjectMapper.Map<Article, ArticleDto>(entity);
                result.IsSuccess(dto);
            }
            return result;
        }

        public async Task<ServiceResult<string>> InsertTestAsync(ArticleDto dto)
        {
            var result = new ServiceResult<string>();
            var entity = ObjectMapper.Map<ArticleDto,Article>(dto); 
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

        public async Task<ServiceResult<string>> UpdateTestAsync(Guid id, ArticleDto dto)
        {
            var result = new ServiceResult<string>();
            var entity = await _testRepository.GetAsync(id);
            if (entity == null)
            {
                result.IsFailed("Test不存在！");
            }
            else
            {
                entity.Title = dto.Title;
                entity.Url = dto.Url;
                await _testRepository.UpdateAsync(entity);
                result.IsSuccess("更新成功！");
            }
            return result;
        }
    }
}
