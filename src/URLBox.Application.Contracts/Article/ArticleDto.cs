using System.Collections.Generic;

namespace URLBox
{
    public class ArticleDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string[] Tags { get; set; }
    }
}
