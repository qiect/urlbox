using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLBox.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users;

namespace URLBox.Repositories
{
    public class UserRepository : EfCoreRepository<URLBoxDbContext, User, Guid>, IUserRepository
    {
        public UserRepository(IDbContextProvider<URLBoxDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
