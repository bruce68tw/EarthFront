//using EarthFront.Tables;
using Base.Services;
using BaseApi.Services;
using BaseWeb.Services;
using EarthFront.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace EarthFront.Services
{
    //project service
#pragma warning disable CA2211 // 非常數欄位不應可見
    public static class _Xp
    {
        //constant
        //public const string MyVer = "20201228f";     //for my.js/css
        public static string MyVer = _Date.NowSecStr(); //for my.js/css
        public const string LibVer = "20220321a";       //for lib.js/css
        public const string JwtToken = "_JwtToken";     //cookie name for jwt token

        public static string NoImagePath = _Fun.DirRoot + "/wwwroot/image/noImage.jpg";

        //JWT key for token
        private static readonly SymmetricSecurityKey _jwtKey =
            new(Encoding.UTF8.GetBytes(_Str.PreZero(16, "YourJwtKey", true)));

        //dir
        public static string DirTpl = _Fun.DirRoot + "_template/";
        public static string DirUpload = _Fun.DirRoot + "_upload/";
        public static string DirLeave = DirUpload + "Leave/";
        public static string DirUserExt = DirUpload + "UserExt/";
        public static string DirUserLicense = DirUpload + "UserLicense/";
        public static string DirCustInput = DirUpload + "CustInput/";
        public static string DirUserImport = DirUpload + "UserImport/";
        //dir cms
        public static string DirCms = DirUpload + "Cms";

        //public static string Locale;
        //public static string LocaleNoDash;

        //view columns 
        //public static int[] ViewCols = new int[] { 12, 2, 3 };

        /*
        public static MyContext GetDb()
        {
            return new MyContext();
        }
        */

        public static string CmsTypeToProgName(string cmsType)
        {
            return cmsType switch
            {
                CmsTypeEstr.Msg => "最新消息維護",
                CmsTypeEstr.Card => "電子賀卡維護",
                _ => "??"
            };
        }

        #region get file path
        public static string PathUserExt(string key, string ext)
        {
            //return _File.GetFirstPath(DirUserExt, "PhotoFile_" + key, NoImagePath);
            return $"{DirUserExt}PhotoFile_{key}.{ext}";
        }
        #endregion

        public static string DirCmsType(string cmsType)
        {
            return DirCms + cmsType + "/";
        }

        #region get file content
        public static async Task<FileResult> ViewLeaveAsync(string fid, string key, string ext)
        {
            return await ViewFileAsync(DirLeave, fid, key, ext);
        }

        public static async Task<FileResult> ViewUserExtAsync(string fid, string key, string ext)
        {
            //return _WebFile.EchoImage(PathUserExt(key));
            return await ViewFileAsync(DirUserExt, fid, key, ext);
        }
        public static async Task<FileResult> ViewUserLicenseAsync(string fid, string key, string ext)
        {
            return await ViewFileAsync(DirUserLicense, fid, key, ext);
        }
        public static async Task<FileResult> ViewCmsTypeAsync(string fid, string key, string ext, string cmsType)
        {
            return await ViewFileAsync(DirCmsType(cmsType), fid, key, ext);
        }
        public static async Task<FileResult> ViewCustInputAsync(string fid, string key, string ext)
        {
            return await ViewFileAsync(DirCustInput, fid, key, ext);
        }

        private static async Task<FileResult> ViewFileAsync(string dir, string fid, string key, string ext)
        {
            var path = $"{dir}{fid}_{key}.{ext}";
            return await _WebFile.ViewFileAsync(path, $"{fid}.{ext}");
        }

        #endregion

        /// <summary>
        /// get locale code without dash sign
        /// </summary>
        /// <returns></returns>
        public static string GetLocale0()
        {
            return _Locale.GetLocaleByUser(false);
        }

        /// <summary>
        /// get template file
        /// </summary>
        /// <returns></returns>
        public static string GetTplPath(string fileName, bool hasLocale)
        {
            var dir = DirTpl;
            if (hasLocale)
                dir += _Locale.GetLocaleByUser() + "/";

            return dir + fileName;
        }

        public static SymmetricSecurityKey GetJwtKey()
        {
            return _jwtKey;
        }

        public static void InitGoogleAuth()
        {
            _GoogleAuth.Init(_Fun.Config.GoogleRedirect, _Fun.Config.GoogleClientId, _Fun.Config.GoogleClientSecret);
        }
        public static void InitFbAuth()
        {
            _FbAuth.Init(_Fun.Config.FbRedirect, _Fun.Config.FbClientId, _Fun.Config.FbClientSecret);
        }

    }//class
#pragma warning restore CA2211 // 非常數欄位不應可見
}