using Haowen.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Haowen.Repositories
{
    public class HaowenRepository : EfCoreRepository<HaowenDbContext, Article, Guid>, IArticleRepository
    {
        public HaowenRepository(IDbContextProvider<HaowenDbContext> dbContextProvider) : base(dbContextProvider)
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
