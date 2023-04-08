using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLBox
{
    /// <summary>
    /// 全局常量
    /// </summary>
    public class URLBoxConsts
    {
        /// <summary>
        /// 数据库表前缀
        /// </summary>
        public const string DbTablePrefix = "";
    }

    /// <summary>
    /// 分组
    /// </summary>
    public static class Grouping
    {

        /// <summary>
        /// 后台接口组
        /// </summary>
        public const string GroupName_Admin = "v1";

        /// <summary>
        /// JWT授权接口组
        /// </summary>
        public const string GroupName_JWT = "v2";
    }

    /// <summary>
    /// 缓存过期时间策略
    /// </summary>
    public static class CacheStrategy
    {
        /// <summary>
        /// 一天过期24小时
        /// </summary>

        public const int ONE_DAY = 1440;

        /// <summary>
        /// 12小时过期
        /// </summary>

        public const int HALF_DAY = 720;

        /// <summary>
        /// 8小时过期
        /// </summary>

        public const int EIGHT_HOURS = 480;

        /// <summary>
        /// 5小时过期
        /// </summary>

        public const int FIVE_HOURS = 300;

        /// <summary>
        /// 3小时过期
        /// </summary>

        public const int THREE_HOURS = 180;

        /// <summary>
        /// 2小时过期
        /// </summary>

        public const int TWO_HOURS = 120;

        /// <summary>
        /// 1小时过期
        /// </summary>

        public const int ONE_HOURS = 60;

        /// <summary>
        /// 半小时过期
        /// </summary>

        public const int HALF_HOURS = 30;

        /// <summary>
        /// 5分钟过期
        /// </summary>
        public const int FIVE_MINUTES = 5;

        /// <summary>
        /// 1分钟过期
        /// </summary>
        public const int ONE_MINUTE = 1;

        /// <summary>
        /// 永不过期
        /// </summary>

        public const int NEVER = -1;
    }

    /// <summary>
    /// ClaimTypes
    /// </summary>
    public static class MyClaimTypes
    {
        public const string QQOpenId = "openid";
        public const string QQName = "nickname";
        public const string QQFigure = "figureurl_qq_1";
        public const string QQGender = "gender";
        public const string Avator = "avator";
    }
}
