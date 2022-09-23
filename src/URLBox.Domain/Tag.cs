using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace URLBox
{
    /// <summary>
    /// 标签
    /// </summary>
    public class Tag : Entity<int>
    {
        public string Name { get; set; }
    }
}
