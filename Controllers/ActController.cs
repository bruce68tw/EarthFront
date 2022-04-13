using BaseApi.Controllers;
using EarthFront.Services;
using Microsoft.AspNetCore.Mvc;

namespace EarthFront.Controllers
{
    public class ActController : ApiCtrl
    {
        /// <summary>
        /// 查詢畫面
        /// </summary>
        /// <param name="page">頁次, base 1</param>
        /// <param name="len">每頁顯示筆數</param>
        /// <param name="filter">-1表示重新查詢</param>
        /// <param name="act">活動名稱, 模糊比對</param>
        /// <returns>查詢結果, 含頁次資訊</returns>
        public async Task<ActionResult> Read(int page = 1, int len = 0, int filter = -1, string act = "")
        {
            ViewBag.ActName = act;
            var dto = await new ActRead().GetPageAsync(page, len, filter, act);
            return View(dto);
        }

        //傳回活動圖檔
        public async Task<FileResult> Image(string key, string ext)
        {
            return await _Xp.ViewActAsync(key, ext);
        }

    }//class
}