using Base.Services;
using BaseApi.Services;
using BaseWeb.Services;
using EarthFront.Models;
using EarthFront.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace EarthFront.Controllers
{
    public class HomeController : Controller
    {
        //[XgLogin]
        public ActionResult Index(string token = "")
        {
            ViewBag.Token = token;  //save to js _xp.token
            return View();
        }
        public ActionResult Login(string url = "")
        {
            return View(new LoginVo() { FromUrl = GetUrl(url) });
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginVo vo)
        {
            #region 1.check input account & password
            //reset UI msg
            vo.AccountMsg = "";
            vo.PwdMsg = "";
            #endregion

            #region 2.check DB password & get user info
            var token = await new HomeService().LoginAsync(vo.Account, vo.Pwd, vo);
            if (_Str.IsEmpty(token))
                goto lab_exit;
            #endregion

            //3.redirect
            return LoginAndRedirect(token);

        lab_exit:
            return View(vo);
        }

        private ActionResult LoginAndRedirect(string token, string url = "")
        {
            _Http.SetCookie(_Xp.JwtToken, token);
            return (url == "")
                ? RedirectToAction("Index")
                : Redirect("~" + GetUrl(url));
        }

        private string GetUrl(string url = "")
        {
            return (url == "")
                ? "" : HttpUtility.UrlDecode(url);
        }

        //show google signIn form
        //param url from url
        public ActionResult OpenGoogle(string url = "")
        {
            _Xp.InitGoogleAuth();
            return Redirect(_GoogleAuth.GetAuthUrl(GetUrl(url)));
        }

        //call after google login
        public async Task<ActionResult> GoogleLogin()
        {
            //check error
            var query = Request.Query;
            var fid = "error";
            if (query.ContainsKey(fid))
            {
                //var error = query[fid][0];
                goto lab_error;
            }
                
            //傳回 code, 繼續讀取 token
            //var userType = query["state"][0];
            var code = query["code"][0];
            if (code != null)
            {
                var token = await _GoogleAuth.CodeToToken(code);
                var user = await _GoogleAuth.GetUser(token);
                var email = user["email"].ToString();
                var jwtToken = await new HomeService().AuthLoginAsync(email);

                //get state for redirect url
                var url = (query["state"].Count == 0 || query["state"][0] == null)
                    ? "" : query["state"][0];

                //轉到首頁
                return LoginAndRedirect(jwtToken, url);
            }

        //case else
        lab_error:
            return PartialView("~/Views/Shared/Error.cshtml");
        }

        public ActionResult OpenFb()
        {
            _Xp.InitFbAuth();
            return Redirect(_FbAuth.GetAuthUrl());
        }

        //call after Facebook login
        public async Task<ActionResult> FbLogin()
        {
            //check error
            var query = Request.Query;
            var fid = "error";
            if (query.ContainsKey(fid))
            {
                //var error = query[fid][0];
                goto lab_error;
            }

            //傳回 code, 繼續讀取 token
            //var userType = query["state"][0];
            var code = query["code"][0];
            if (code != null)
            {
                var token = await _FbAuth.CodeToToken(code);
                var user = await _FbAuth.GetUser(token);
                //await _Log.InfoAsync(_Json.ToStr(user));
                var email = user["email"].ToString();
                var jwtToken = await new HomeService().AuthLoginAsync(email);

                //轉到首頁
                return LoginAndRedirect(jwtToken);
            }

        //case else
        lab_error:
            return PartialView("~/Views/Shared/Error.cshtml");
        }

        public ActionResult Create()
        {
            return View(new LoginVo());
        }

        public ActionResult Logout()
        {
            return LoginAndRedirect("");
        }

        public ActionResult Error()
        {
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return View("Error", (error == null) ? _Fun.SystemError : error.Error.Message);
        }

    }//class
}