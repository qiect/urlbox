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

        /// <summary>
        /// 删除文章通过ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResult> DeleteArticleAsync(Guid id)
        {
            var result = new ServiceResult();
            await _articleRepository.DeleteAsync(id);
            return result;
        }

        /// <summary>
        /// 获取文章通过ID，todo：标签未处理
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            var articleList = await _articleRepository.GetListAsync();
            var tagList = await _tagRepository.GetListAsync();
            var articleDtos = new List<ArticleDto>();
            foreach (var item in articleList)
            {
                articleDtos.Add(new ArticleDto
                {
                    Title = item.Title,
                    Icon = item.Icon,
                    Url = item.Url,
                    Des = item.Des,
                    Tags = tagList.Where(p => JsonConvert.DeserializeObject<int[]>(item.Tags).Contains(p.Id)).Select(p => p.Name).ToArray(),
                });
            }
            var result = new ServiceResult<string>();
            result.IsSuccess(JsonConvert.SerializeObject(articleDtos,  new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            }));
            return result;
        }

        /// <summary>
        /// 批量插入文章
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> BatchInsertArticleAsync(ArticleDto[] dtos)
        {
            var result = new ServiceResult<string>();
            foreach (var item in dtos)
            {
                await InsertArticleAsync(item);
            }
            result.IsSuccess("批量插入完成！");
            return result;
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> InsertArticleAsync(ArticleDto dto)
        {
            var result = new ServiceResult<string>();
            var entity = ObjectMapper.Map<ArticleDto, Article>(dto);
            var iTags = new int[dto.Tags.Length];
            //新增标签
            for (int i = 0; i < dto.Tags.Length; i++)
            {
                var tagEntity = await _tagRepository.FindAsync(p => p.Name.Equals(dto.Tags[i]));
                if (tagEntity == null)
                {
                    tagEntity = await _tagRepository.InsertAsync(new Tag
                    {
                        Name = dto.Tags[i]
                    }, true);
                }
                iTags[i] = tagEntity.Id;
            };
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

        /// <summary>
        /// 修改文章，todo：标签未处理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
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
