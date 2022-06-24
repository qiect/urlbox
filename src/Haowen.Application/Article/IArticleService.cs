using Haowen.ToolKits.Base;
namespace Haowen
{
    public interface IArticleService
    {
        //Task<bool> InsertTestAsync(TestDto dto);
        Task<ServiceResult<string>> InsertTestAsync(ArticleDto dto);


        //Task<bool> DeleteTestAsync(Guid id);
        Task<ServiceResult> DeleteTestAsync(Guid id);


        //Task<bool> UpdateTestAsync(Guid id, TestDto dto);
        Task<ServiceResult<string>> UpdateTestAsync(Guid id, ArticleDto dto);


        //Task<TestDto> GetTestAsync(Guid id);
        Task<ServiceResult<ArticleDto>> GetTestAsync(Guid id);

    }
}
