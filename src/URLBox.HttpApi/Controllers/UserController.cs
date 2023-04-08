using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using URLBox.Configurations;
using Volo.Abp.AspNetCore.Mvc;

namespace URLBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_Admin)]
    public class UserController : AbpController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("login")]
        public void LoginQQ(string provider = "QQ", string returnUrl = null)
        {
            //第三方登录成功后跳转的地址
            var redirectUrl = Url.Action(nameof(ExternalLoginCallbackAsync), new { returnUrl });
            var properties = new AuthenticationProperties()
            {
                RedirectUri = redirectUrl
            };
            Challenge(properties, provider);
        }

        [Authorize]
        private async Task ExternalLoginCallbackAsync(string returnUrl = null)
        {
            //QQ认证后会默认登录，如果你想自定义登录，可以先注销第三方登录的身份
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            string openId = "", name = "", figure = "", gender = "";
            //从当前登录用户的身份声明中获取信息（是否有些眼熟，MyClaimTypes就是在Startup里面自定义的那些）
            foreach (var item in HttpContext.User.Claims)
            {
                switch (item.Type)
                {
                    case MyClaimTypes.QQOpenId:
                        openId = item.Value;
                        break;
                    case MyClaimTypes.QQName:
                        name = item.Value;
                        break;
                    case MyClaimTypes.QQFigure:
                        figure = item.Value;
                        break;
                    case MyClaimTypes.QQGender:
                        gender = item.Value;
                        break;
                    default:
                        break;
                }
            }
            try
            {
                //获取到OpenId后进行登录或者注册（以下作为示范，不要盲目复制粘贴）
                if (!string.IsNullOrEmpty(openId))
                {
                    //去数据库查询该QQ是否绑定用户
                    var user = await _userService.GetByQQOpenIdAsync(openId);
                    if (user != null)
                    {
                        #region 存在则登陆
                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                        identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
                        identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                        identity.AddClaim(new Claim(MyClaimTypes.Avator, user.Avatar));
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.Now.Add(TimeSpan.FromDays(int.Parse(AppSettings.Authentication.LoginExpires))) // 有效时间
                        });
                        user.LastLoginIP = HttpContext.Connection.RemoteIpAddress.ToString();
                        user.LastLoginTime = DateTime.Now;
                        //更新登录信息
                        _userService.Update(user.QQOpenId, user.LastLoginIP, user.LastLoginTime);
                        #endregion
                        if (returnUrl != null)
                            Redirect($"~{returnUrl}");
                        else
                            Redirect("~/");
                    }
                    else
                    {
                        //注册
                        var userDto = await _userService.AddAsync(openId, name, figure, gender);
                        if (userDto != null)
                        {
                            #region 注册后自动登陆
                            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                            identity.AddClaim(new Claim(ClaimTypes.Sid, userDto.Id.ToString()));
                            identity.AddClaim(new Claim(ClaimTypes.Name, userDto.Name));
                            identity.AddClaim(new Claim(MyClaimTypes.Avator, userDto.Avatar));
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
                            {
                                IsPersistent = true,
                                ExpiresUtc = DateTimeOffset.Now.Add(TimeSpan.FromDays(int.Parse(AppSettings.Authentication.LoginExpires))) // 有效时间
                            });
                            userDto.LastLoginIP = HttpContext.Connection.RemoteIpAddress.ToString();
                            userDto.LastLoginTime = DateTime.Now;
                            //更新登录信息
                            _userService.Update(openId, userDto.LastLoginIP, userDto.LastLoginTime);
                            #endregion
                            if (returnUrl != null)
                                Redirect($"~{returnUrl}");
                            else
                                Redirect("~/");
                        }
                        else
                            throw new Exception("Add User failed");
                    }
                }
                else
                    throw new Exception("OpenId is null");
            }
            catch (Exception ex)
            {
                throw new Exception("登录发生错误");
            }
        }

        [HttpGet("signout")]
        public async Task SignOut(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (returnUrl != null)
                Redirect($"~{returnUrl}");
            else
                Redirect("~/");
        }

    }
}
