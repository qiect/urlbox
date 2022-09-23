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
    public class TagRepository : EfCoreRepository<URLBoxDbContext, Tag, int>, ITagRepository
    {
        public TagRepository(IDbContextProvider<URLBoxDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
