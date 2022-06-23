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
    public class TestRepository : EfCoreRepository<TemplateDbContext, Test, Guid>, ITestRepository
    {
        public TestRepository(IDbContextProvider<TemplateDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task BatchInsertAsync(IEnumerable<Test> tests)
        {
            var dbCtx = await GetDbContextAsync();
            await dbCtx.Tests.AddRangeAsync(tests);
            await dbCtx.SaveChangesAsync();
        }
    }
}
