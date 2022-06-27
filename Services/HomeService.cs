using Base.Services;
using EarthFront.Models;
using EarthFront.Tables;
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
            var db = _Xp.GetDb();
            var row = db.UserFront
                .Where(a => a.Email == email && a.Status)
                .Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.Pwd
                })
                .FirstOrDefault();

            /*
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
            */
            string userId;
            string name;
            bool hasPwd = false;
            if (row == null)
            {
                //userId = _Str.NewId();
                userId = _Str.NewId();
                name = _Str.GetLeft(email, "@");
                var newUser = new UserFront()
                {
                    Id = userId,
                    Name = name,
                    Email = email,
                    Status = true,
                    Created = DateTime.Now,
                };
                db.UserFront.Add(newUser);
                await db.SaveChangesAsync();

                /*
                userId = new Guid();
                name = _Str.GetLeft(email, "@");
                sql = $@"
insert into dbo.UserFront (Id, Name, Email, Status, Created)
values ('{userId}', '{name}', @Email, 1, getdate())
";
                await db.ExecSqlAsync(sql, args);
                */
            }
            else
            {
                userId = row.Id;
                name = row.Name;
                hasPwd = _Str.NotEmpty(row.Pwd);
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
        public string Login(LoginVo vo)
        {
            //check DB password & get user info
            using var db = _Xp.GetDb();
            var row = db.UserFront
                .Where(a => a.Account == vo.Account && a.Status)
                .Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.Pwd
                })
                .FirstOrDefault();

            var status = false;
            var hasPwd = _Str.NotEmpty(vo.Pwd);
            if (row != null)
            {
                var dbPwd = row.Pwd;
                status = (!hasPwd && dbPwd == "") ||
                    (hasPwd && dbPwd == _Str.Md5(vo.Pwd));
            }
            if (!status)
            {
                vo.ErrorMsg = "輸入錯誤。";
                return "";
            }

            //3.set JWT token
            return new HomeService().GetJwtToken(row.Id, row.Name, hasPwd);
        }

        public string GetJwtToken(string userId, string userName, bool hasPwd)
        {
            //var userId = row["UserId"].ToString();
            //var userName = row["UserName"].ToString();
            var token = new JwtSecurityToken(
                claims: new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
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