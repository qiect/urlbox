using URLBox.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace URLBox.Repositories
{
    public class ArticleRepository : EfCoreRepository<URLBoxDbContext, Article, Guid>, IArticleRepository
    {
        public ArticleRepository(IDbContextProvider<URLBoxDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task BatchInsertAsync(IEnumerable<Article> tests)
        {
            var dbCtx = await GetDbContextAsync();
            await dbCtx.Articles.AddRangeAsync(tests);
            await dbCtx.SaveChangesAsync();
        }
    }
}
