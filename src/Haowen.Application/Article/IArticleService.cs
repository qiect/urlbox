using Haowen.ToolKits.Base;
namespace Haowen
{
    public interface IArticleService
    {
        //Task<bool> InsertArticleAsync(ArticleDto dto);
        Task<ServiceResult<string>> InsertArticleAsync(ArticleDto dto);


        //Task<bool> DeleteArticleAsync(Guid id);
        Task<ServiceResult> DeleteArticleAsync(Guid id);


        //Task<bool> UpdateArticleAsync(Guid id, ArticleDto dto);
        Task<ServiceResult<string>> UpdateArticleAsync(Guid id, ArticleDto dto);


        //Task<ArticleDto> GetArticleAsync(Guid id);
        Task<ServiceResult<ArticleDto>> GetArticleAsync(Guid id);

        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> GetArticlesAsync();

    }
}
