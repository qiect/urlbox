﻿using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Haowen
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article : Entity<Guid>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
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
        public string Tags { get; set; }
    }
}