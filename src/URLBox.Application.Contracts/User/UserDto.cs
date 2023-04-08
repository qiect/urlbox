using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLBox
{
    public class UserDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 邮箱状态
        /// </summary>
        public string EmailStatus { get; set; }
        /// <summary>
        /// 邮箱验证码
        /// </summary>
        public string VCode { get; set; }
        /// <summary>
        /// 登录错误次数
        /// </summary>
        public int LoginErrorTimes { get; set; }
        /// <summary>
        /// 最后一次登录错误时间
        /// </summary>
        public DateTime? LastLoginErrorDateTime { get; set; }
        /// <summary>
        /// QQOpenId
        /// </summary>
        public string QQOpenId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 最后一次登录IP
        /// </summary>
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public string IsDeleted { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeletedDateTime { get; set; }
    }
}
