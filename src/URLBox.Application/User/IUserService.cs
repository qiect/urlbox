using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLBox
{
    public interface IUserService
    {
        Task<UserDto> GetByQQOpenIdAsync(string qqOpenId);
        Task<UserDto> AddAsync(string qqOpenId, string name, string avatar, string gender);
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        void Update(string qQOpenId, string lastLoginIP, DateTime? lastLoginTime);
    }
}
