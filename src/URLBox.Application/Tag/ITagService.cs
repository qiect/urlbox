using URLBox.ToolKits.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLBox
{
    public interface ITagService
    {
        /// <summary>
        /// 获取所有标签
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> GetTagAsync();
    }
}
