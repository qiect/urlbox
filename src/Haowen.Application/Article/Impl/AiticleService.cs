using Haowen.Repositories;
using Haowen.ToolKits.Base;
using Newtonsoft.Json;

namespace Haowen
{
    public class AiticleService : ServiceBase, IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public AiticleService(IArticleRepository articleRepository)
        {
            this._articleRepository = articleRepository;
        }

        public async Task<ServiceResult> DeleteArticleAsync(Guid id)
        {
            var result = new ServiceResult();
            await _articleRepository.DeleteAsync(id);
            return result;
        }

        public async Task<ServiceResult<ArticleDto>> GetArticleAsync(Guid id)
        {
            var result = new ServiceResult<ArticleDto>();
            var entity = await _articleRepository.GetAsync(id);
            if (entity == null)
            {
                result.IsFailed("Article不存在！");
            }
            else
            {
                var dto = ObjectMapper.Map<Article, ArticleDto>(entity);
                result.IsSuccess(dto);
            }
            return result;
        }

        public async Task<ServiceResult<string>> GetArticlesAsync()
        {
            var entityList = await _articleRepository.GetListAsync();
            var articleDtos = new List<ArticleDto>();
            foreach (var entity in entityList)
            {
                new ArticleDto
                {
                    Title = entity.Title,
                    Url = entity.Url,
                    Icon = entity.Icon,
                    Des = entity.Des,
                    Tags = $"[{string.Join(',', entity.Tags.Select(p => "\"" + p.Name + "\""))}]",
                };
            }
            var result = new ServiceResult<string>();
            result.IsSuccess(JsonConvert.SerializeObject(articleDtos));
            return result;
        }


        public async Task<ServiceResult<string>> InsertArticleAsync(ArticleDto dto)
        {
            var result = new ServiceResult<string>();
            var entity = ObjectMapper.Map<ArticleDto, Article>(dto);
            var Article = await _articleRepository.InsertAsync(entity);
            if (Article != null)
            {
                result.IsSuccess("添加成功！");
            }
            else
            {
                result.IsFailed("添加失败！");
            }
            return result;
        }

        public async Task<ServiceResult<string>> UpdateArticleAsync(Guid id, ArticleDto dto)
        {
            var result = new ServiceResult<string>();
            var entity = await _articleRepository.GetAsync(id);
            if (entity == null)
            {
                result.IsFailed("Article不存在！");
            }
            else
            {
                entity.Title = dto.Title;
                entity.Url = dto.Url;
                await _articleRepository.UpdateAsync(entity);
                result.IsSuccess("更新成功！");
            }
            return result;
        }
    }
}
