using Base.Services;
using EarthFront.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EarthFront.Services
{
    public class HomeService
    {

        /// <summary>
        /// oAuth2 login
        /// </summary>
        /// <param name="email"></param>
        /// <returns>jwt token</returns>
        public async Task<string> AuthLoginAsync(string email)
        {
            //check email existed
            string userId, name;
            var sql = @"
select Id, Name, Pwd
from dbo.UserFront 
where Email=@Email
and Status=1
";
            var hasPwd = false;
            var db = new Db();
            var args = new List<object> { "Email", email.ToLower() };
            var row = await db.GetJsonAsync(sql, args);
            if (row == null)
            {
                userId = _Str.NewId();
                name = _Str.GetLeft(email, "@");
                sql = $@"
insert into dbo.UserFront (Id, Name, Email, Status, Created)
values ('{userId}', '{name}', @Email, 1, getdate())
";
                await db.ExecSqlAsync(sql, args);
            }
            else
            {
                userId = row["Id"].ToString();
                name = row["Name"].ToString();
                hasPwd = _Str.NotEmpty(row["Pwd"].ToString());
            }

            await db.DisposeAsync();
            return GetJwtToken(userId, name, hasPwd);
        }

        /// <summary>
        /// login by account/pwd, async 不可使用 ref !!
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="token">JWT token call by ref</param>
        /// <returns>jwt token</returns>
        public async Task<string> LoginAsync(string account, string pwd, LoginVo vo)
        {
            #region 2.check DB password & get user info
            var sql = @"
select Id, Name, Pwd
from dbo.UserFront
where Account=@Account
";
            var status = false;
            var hasPwd = _Str.NotEmpty(pwd);
            var row = await _Db.GetJsonAsync(sql, new List<object>{ "Account", account });
            if (row != null)
            {
                var dbPwd = row["Pwd"].ToString();
                status = (!hasPwd && dbPwd == "") ||
                    (hasPwd && dbPwd == _Str.Md5(pwd));
            }
            if (!status)
            {
                vo.AccountMsg = "Input Wrong. ";
                return "";
            }
            #endregion

            //3.set JWT token
            return new HomeService().GetJwtToken(row["Id"].ToString(),
                row["Name"].ToString(), hasPwd);
        }

        public string GetJwtToken(string userId, string userName, bool hasPwd)
        {
            //var userId = row["UserId"].ToString();
            //var userName = row["UserName"].ToString();
            var token = new JwtSecurityToken(
                claims: new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, hasPwd ? "1" : "0"), //0 for empty pwd user
                },
                signingCredentials: new SigningCredentials(
                    _Xp.GetJwtKey(),
                    SecurityAlgorithms.HmacSha256
                ),
                expires: DateTime.Now.AddMinutes(60)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    } //class
}
