using Base.Models;
using Base.Services;
using BaseApi.Services;
using BaseWeb.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace EarthFront.Services
{
    public class MyBaseUserService : IBaseUserService
    {
        //get base user info
        public BaseUserDto GetData()
        {
            //var authStr = _Http.GetRequest().Headers["Authorization"]
            //    .ToString().Replace("Bearer ", "");
            var authStr = _Http.GetCookie(_Xp.JwtToken);
            if (_Str.IsEmpty(authStr))
            {
                return new BaseUserDto()
                {
                    UserId = "",
                    UserName = "(Empty)",
                    IsLogin = false,
                    HasPwd = false,
                    Locale = _Fun.Config.Locale,
                };
            }

            var token = new JwtSecurityTokenHandler().ReadJwtToken(authStr);
            var userId = token.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userName = token.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            var hasPwd = (token.Claims.First(c => c.Type == ClaimTypes.Role).Value == "1");
            return new BaseUserDto()
            {
                UserId = userId,
                UserName = userName,
                HasPwd = hasPwd,
                Locale = _Fun.Config.Locale,
            };
        }
    }
}
