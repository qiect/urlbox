using URLBox.ToolKits.Base;
namespace URLBox
{
    public interface IArticleService
    {
        /// <summary>
        /// 批量插入好文
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> BatchInsertArticleAsync(ArticleDto[] dtos);
        /// <summary>
        /// 添加好文
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> InsertArticleAsync(ArticleDto dto);
        /// <summary>
        /// 删除好文
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task<ServiceResult> DeleteArticleAsync(Guid id);
        /// <summary>
        /// 修改好文
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>

        Task<ServiceResult<string>> UpdateArticleAsync(Guid id, ArticleDto dto);
        /// <summary>
        /// 获取好文
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResult<ArticleDto>> GetArticleAsync(Guid id);
        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> GetArticlesAsync();

    }
}
