using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLBox.Repositories;
using Volo.Abp.Domain.Repositories;

namespace URLBox
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> AddAsync(string qqOpenId, string name, string avatar, string gender)
        {
            //检查手机号不能重复
            bool exists = await _userRepository.AnyAsync(u => u.QQOpenId == qqOpenId);
            if (exists)
            {
                throw new ArgumentException("用户已经存在");
            }
            User user = new User();
            user.QQOpenId = qqOpenId;
            user.Name = name;
            user.Avatar = avatar;
            user.Gender = gender;
            var result = await _userRepository.InsertAsync(user, true);
            return ObjectMapper.Map<User, UserDto>(result);
        }

        public async Task<UserDto> GetByQQOpenIdAsync(string qqOpenId)
        {
            var result = await _userRepository.SingleOrDefaultAsync(p => p.QQOpenId == qqOpenId);
            return result == null ? null : ObjectMapper.Map<User, UserDto>(result);
        }

        public async void Update(string qqOpenId, string lastLoginIP, DateTime? lastLoginTime)
        {
            //检查openId不能重复
            var user = await _userRepository.SingleOrDefaultAsync(p => p.QQOpenId.Equals(qqOpenId));
            if (user == null)
            {
                throw new ArgumentException("用户不存在 " + qqOpenId);
            }
            user.LastLoginIP = lastLoginIP;
            user.LastLoginTime = lastLoginTime;
            await _userRepository.UpdateAsync(user);
        }

    }
}
