﻿using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace URLBox.Filters
{
    public class URLBoxExceptionFilter: IExceptionFilter
    {
        private readonly ILog _log;

        public URLBoxExceptionFilter()
        {
            _log = LogManager.GetLogger(typeof(URLBoxExceptionFilter));
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void OnException(ExceptionContext context)
        {
            // 错误日志记录
            _log.Error($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
