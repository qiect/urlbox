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
    public class TagRepository : EfCoreRepository<HaowenDbContext, Tag, int>, ITagRepository
    {
        public TagRepository(IDbContextProvider<HaowenDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
