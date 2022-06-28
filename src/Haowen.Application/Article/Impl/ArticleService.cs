using Haowen.Repositories;
using Haowen.ToolKits.Base;
using Newtonsoft.Json;

namespace Haowen
{
    public class ArticleService : ServiceBase, IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ITagRepository _tagRepository;

        public ArticleService(IArticleRepository articleRepository, ITagRepository tagRepository)
        {
            this._articleRepository = articleRepository;
            this._tagRepository = tagRepository;
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

        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetArticlesAsync()
        {
            var entityList = await _articleRepository.WithDetailsAsync(p => p.Tags);
            var articleDtos = ObjectMapper.Map<List<Article>, List<ArticleDto>>(entityList.ToList());
            var result = new ServiceResult<string>();
            result.IsSuccess(JsonConvert.SerializeObject(articleDtos));
            return result;
        }


        public async Task<ServiceResult<string>> InsertArticleAsync(ArticleDto dto)
        {
            var result = new ServiceResult<string>();
            var entity = ObjectMapper.Map<ArticleDto, Article>(dto);
            var iTags = new int[dto.Tags.Length];
            //新增标签
            foreach (var tag in dto.Tags)
            {
                var tagEntity = await _tagRepository.FindAsync(p => p.Name.Equals(tag));
                if (tagEntity == null)
                {
                    tagEntity = await _tagRepository.InsertAsync(new Tag
                    {
                        Name = tag
                    }, true);
                }
                iTags.AddLast(tagEntity.Id);
            }
            entity.Tags = JsonConvert.SerializeObject(iTags);
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
