using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace URLBox.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}
