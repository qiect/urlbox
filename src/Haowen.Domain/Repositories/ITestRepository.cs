using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Haowen.Repositories
{
    public interface ITestRepository : IRepository<Test, Guid>
    {
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="tests"></param>
        /// <returns></returns>
        Task BatchInsertAsync(IEnumerable<Test> tests);
    }
}
