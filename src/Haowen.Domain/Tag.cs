using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Haowen
{
    /// <summary>
    /// 标签
    /// </summary>
    public class Tag : Entity<int>
    {
        public string Name { get; set; }
    }
}
